const kinveyBaseUrl = 'https://baas.kinvey.com/';
const kinveyAppKey = 'Enter app key here';
const kinveyAppSecret = 'Enter app secret here';

function handleError(response) {
    let errorMsg = JSON.stringify(response);
    if (response.readyState === 0) {
        errorMsg = 'Cannot connect due to network error.'
    }

    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }

    showError(errorMsg);
}

function showView(viewName) {
    $('main > section').hide();
    $('#' + viewName).show();
}

function manageMenuLinks() {
    $('linkHome').show();
    if (!sessionStorage['authToken']) {
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkLogout').hide();
        $('#linkListBooks').hide();
        $('#linkCreateBooks').hide();
    } else {
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkLogout').show();
        $('#linkListBooks').show();
        $('#linkCreateBooks').show();
    }
}

function showInfo(message) {
    $('#infoBox').text(message).show();
    /* $('#infoBox').show();*/
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000);
}

function showError(message) {
    $('#errorBox').text('Error' + message).show();
    /* $('#errorBox').show();*/
}

$(function () {
    manageMenuLinks();
    showView('viewHome');

    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkCreateBooks').click(showCreateBooksView);
    $('#linkListBooks').click(showListBooksView);
    $('#linkLogout').click(showLogoutView);

    $('#formLogin').submit(function (e) {
        e.preventDefault();
        login();
    });

    $('#formRegister').submit(function (e) {
        e.preventDefault();
        register();
    });

    $('#formCreateBook').submit(function (e) {
        e.preventDefault();
        createBook();
    });

    $(document).on({
            ajaxStart: function () {
                $('#loadingBox').show()
            },
            ajaxStop: function () {
                $('#loadingBox').hide()
            }
        }
    )
});

function showHomeView() {
    showView('viewHome');
}

function showLoginView() {
    showView('viewLogin');
}

function showRegisterView() {
    showView('viewRegister');
}

function showCreateBooksView() {
    showView('viewCreateBook');
}

function showListBooksView() {
    showView('viewBooks');
    listBooks();
}

function showLogoutView() {
    sessionStorage.clear();
    manageMenuLinks();
    showView('viewHome');
}

function login() {
    const loginUrl = kinveyBaseUrl + 'user/' + kinveyAppKey + '/login';
    const authorizationHeaders = {
        'Authorization': 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret),
    };

    let userData = {
        username: $('#loginUsernameText').val(),
        password: $('#loginPasswordText').val()
    };

    $.ajax({
        method: 'POST',
        url: loginUrl,
        headers: authorizationHeaders,
        data: userData,
        success: loginSuccess,
        error: handleError
    });

    function loginSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        manageMenuLinks();
        listBooks();
        showInfo('Login successful!');
    }

    function handleError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0) {
            errorMsg = 'Cannot connect due to network error.'
        }

        if (response.responseJSON && response.responseJSON.description) {
            errorMsg = response.responseJSON.description;
        }
        showError(errorMsg);
    }
}

function register() {
    const registerUrl = kinveyBaseUrl + 'user/' + kinveyAppKey + '/';
    const authorizationHeaders = {
        'Authorization': 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret)
    };

    let userData = {
        username: $('#registerUsernameText').val(),
        password: $('#registerPasswordText').val()
    };

    $.ajax({
        method: 'POST',
        url: registerUrl,
        headers: authorizationHeaders,
        data: userData,
        success: registerSuccess,
        error: handleError
    });

    function registerSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        manageMenuLinks();
        listBooks();
        showInfo('Register successful!');

    }

}

function listBooks() {
    $('#books').empty();
    showView('viewBooks');

    const booksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const authorizationHeaders = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    };

    $.ajax({
        method: 'GET',
        url: booksUrl,
        headers: authorizationHeaders,
        success: loadBooksSuccess,
        error: handleError
    });

    function loadBooksSuccess(books) {
        showInfo('Books loaded.');

        if (books.length === 0) {
            $('#viewBooks').text('');
            $('#books').text('No books in library.');
        } else {
            let bookTable = $('<table>')
                .append('<tr>')
                .append('<th>Title</th>', '<th>Author</th>', '<th>Description</th>');

            for (let book of books) {
                bookTable.append($('<tr>').append(
                    $('<td>').text(book.title),
                    $('<td>').text(book.author),
                    $('<td>').text(book.description))
                );

                let commentsRow = $('<tr>')
                    .addClass('commentRow')
                    .attr('data-question', JSON.stringify(book));

                let commentsSection = $('<td colspan="3">');

                if (book.comments) {
                    appendBookCommentsRow(commentsSection, book);
                    commentsRow.append(commentsSection);
                }

                appendAddCommentRow(commentsSection, book);

                commentsRow.append(commentsSection);
                bookTable.append(commentsRow);

                function appendBookCommentsRow(bookCommentsRow, book) {

                    for (let comment of book.comments) {
                        let text = comment.text;
                        let author = comment.author;
                        bookCommentsRow
                            .append(
                                $('<div>').addClass('bookCommentsText').html(text),
                                $('<div style="font-style: italic">').addClass('bookCommentsAuthor').html('&emsp;-- ' + author),
                                $('<br>')
                            );
                    }
                }

                function getAddCommentsForm() {
                    let commentForm = $('<form style="display: none">')
                        .addClass('formComment')
                        .on('submit', function (e) {
                            let bookData = JSON.parse($(this).closest('tr').attr('data-question'));
                            let commentText = $(this).find('.textComment').val();
                            let commentAuthor = $(this).find('.textCommentAuthor').val();

                            $(this).find('.textComment').val('');
                            $(this).find('.textCommentAuthor').val('');

                            e.preventDefault();

                            addBookComment(bookData, commentText, commentAuthor);

                            $(this).hide();
                            $(this).closest('tr').find('.hyperlinkAddComment').show()
                        })
                        .on('reset', function (e) {
                            $(this).hide();
                            $(this).closest('tr').find('.hyperlinkAddComment').show()
                        })
                        .append($('<span>Comment: </span>'))
                        .append($('<input type="text" required>').addClass('textComment'))
                        .append($('<span>Author: </span>'))
                        .append($('<input type="text" required>').addClass('textCommentAuthor'))
                        .append($('<input type="submit" value="Add comment">'))
                        .append($('<input type="reset" value="Cancel">'));
                    return commentForm;
                }

                function appendAddCommentRow(commentsSection, book) {
                    commentsSection.append(
                        (($('<div></div>')
                            .addClass('bookCommentsAuthor'))
                            .append($('<a href="#">Add Comment</a>')
                                .click(function () {
                                    $(this).hide();
                                    $(this).closest('tr').find('.formComment').show();
                                })
                                .addClass('hyperlinkAddComment'))));

                    let commentForm = getAddCommentsForm();
                    commentsSection.append(commentForm);
                }
            }

            $('#paragraphBookProgress').text("");
            $('#books').append(bookTable);
        }
    }

    function handleError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0) {
            errorMsg = 'Cannot connect due to network error.'
        }

        if (response.responseJSON && response.responseJSON.description) {
            errorMsg = response.responseJSON.description;
        }

        showError(errorMsg);
    }
}

function createBook() {
    const createBookUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const authorizationHeaders = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    };

    let bookData = {
        title: $('#creteBookTitleText').val(),
        author: $('#createBookAuthorText').val(),
        description: $('#createBookDescriptionText').val(),
        comments: []
    };

    $('#creteBookTitleText').val(' ');
    $('#createBookAuthorText').val(' ');
    $('#createBookDescriptionText').val(' ');

    $.ajax({
        method: 'POST',
        url: createBookUrl,
        headers: authorizationHeaders,
        data: bookData,
        success: bookSuccess,
        error: handleError
    });

    function bookSuccess(response) {
        listBooks();
        showInfo('Book added!');
    }

    function handleError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0) {
            errorMsg = 'Cannot connect due to network error.'
        }

        if (response.responseJSON && response.responseJSON.description) {
            errorMsg = response.responseJSON.description;
        }

        showError(errorMsg);
    }
}

function addBookComment(bookData, commentText, commentAuthor) {
    "use strict";
    
    const kinveyBookUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const kinveyHeaders = {
        Authorization: "Kinvey " + sessionStorage.getItem('authToken'),
        'Content-type': 'application/json'
    };

    if (!bookData.comments) {
        bookData.comments = [];
    }

    bookData.comments.push({text: commentText, author: commentAuthor});

    $.ajax({
        method: 'PUT',
        url: kinveyBookUrl + '/' + bookData._id,
        headers: kinveyHeaders,
        data: JSON.stringify(bookData),
        success: addBookCommentSuccess,
        error: handleError
    });

    function addBookCommentSuccess() {
        listBooks();
        showInfo('Book comment added.');
    }
}