namespace BuhtigIssueTracker.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Core;
    using BuhtigIssueTracker.Enums;
    using BuhtigIssueTracker.Models;
    using BuhtigIssueTracker.Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public BuhtigIssueTrackerData Data { get; private set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentUser != null)
            {
                return Constants.AlreadyLoggedUserWarning; 
            }

            if (password != confirmPassword)
            {
                return Constants.PasswordDoNotMatchWarning;
            }

            if (this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format(Constants.UsernameAlreadyExistWarning, username);
            }

            var user = new User(username, password);
            this.Data.UsersByUsername.Add(username, user);

            return string.Format(Constants.RegistrationSuccessfulMessage, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentUser != null)
            {
                return Constants.AlreadyLoggedUserWarning;
            }

            if (!this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format(Constants.UserDoesNotExistWarning, username);
            }

            var user = this.Data.UsersByUsername[username];
            if (user.PasswordHash != User.HashPassword(password))
            {
                return string.Format(Constants.InvalidPasswordWarning, username);
            }

            this.Data.CurrentUser = user;

            return string.Format(Constants.SuccessfulLogInMessage, username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.CurrentlyNoLoggedUser;
            }

            string username = this.Data.CurrentUser.UserName;
            this.Data.CurrentUser = null;

            return string.Format(Constants.SuccessfulLogOutMessage, username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] stringTags)
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.AlreadyLoggedUserWarning;
            }

            var tags = stringTags.Distinct().ToList();
            var issue = new Issue(title, description, priority, tags);
            this.Data.AddIssue(issue);

            // ToDo: Should AddIssue return type?
            return string.Format(Constants.SuccessfullIssueCreationMessage, issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.CurrentlyNoLoggedUser;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Constants.NoIssueFoundWarning, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.Data.CurrentUser.UserName].Contains(issue))
            {
                return string.Format(Constants.NotYourIssueWarning, issueId, this.Data.CurrentUser.UserName);
            }

            this.Data.RemoveIssue(issue);
            return string.Format(Constants.SuccessfullyRemovedIssueMessage, issueId);
        }

        public string AddComment(int intValue, string stringValue)
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.CurrentlyNoLoggedUser;
            }

            if (!this.Data.IssuesById.ContainsKey(intValue))
            {
                return string.Format(Constants.NoIssueFoundWarning, intValue);
            }

            var issue = this.Data.IssuesById[intValue];
            var comment = new Comment(this.Data.CurrentUser, stringValue);
            issue.AddComment(comment);
            this.Data.UserComments[this.Data.CurrentUser].Add(comment);

            return string.Format(Constants.SuccessfullyAddedComment, issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.CurrentlyNoLoggedUser;
            }

            var issues = this.Data.IssuesByUsername[this.Data.CurrentUser.UserName];
            var newIssues = issues;

            if (!newIssues.Any())
            {
                // PERFORMANCE: Working with multiple strings in a foreach loop - resulting bad performance.
                return Constants.NoIssuesFoundWarning;
            }

            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentUser == null)
            {
                return Constants.CurrentlyNoLoggedUser;
            }

            var comments = this.Data.UserComments[this.Data.CurrentUser].Select(comment => comment.ToString());

            if (!comments.Any())
            {
                return Constants.NoCommentsFound;
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < 0)
            {
                return Constants.NoTagsWarning;
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.IssuesByTag[tag]);
            }

            if (!issues.Any())
            {
                return Constants.NoMatchingTagsWarning;
            }

            var uniqueIssues = issues.Distinct();
            if (!uniqueIssues.Any())
            {
                return Constants.NoIssuesFoundWarning;
            }

            return string.Join(Environment.NewLine, uniqueIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}
