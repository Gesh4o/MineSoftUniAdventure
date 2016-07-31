import javax.persistence.*;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DbMain {
    public static void main(String[] args) {
        Logger.getLogger("org.hibernate").setLevel(Level.SEVERE);
        EntityManagerFactory emf = Persistence
                .createEntityManagerFactory("blog-db");
        EntityManager em = emf.createEntityManager();

        try {

            // addPesho(emf, em);
            addUserAndPosts(em);
            //queryPosts(em);

            queryPeshoPosts(em);
            modifyUser(em);
            deleteUser(em);
            postBetweenDatesSql(em);
        }finally {
            em.close();
            emf.close();
        }
    }

    private static void postBetweenDatesSql(EntityManager em) {
        LocalDateTime startDate =
                LocalDateTime.parse("2016-05-19T12:00:00");
        LocalDateTime endDate = LocalDateTime.now();
        Query postsQuery = em.createNativeQuery(
                "SELECT id, title, date, body, author_id FROM posts " +
                        "WHERE CONVERT(date, Date) " +
                        "BETWEEN :startDate AND :endDate", Post.class)
                .setParameter("startDate", startDate)
                .setParameter("endDate", endDate);
        List<Post> posts = postsQuery.getResultList();
        for (Post post : posts)
            System.out.println(post);
    }

    private static void deleteUser(EntityManager em) {
        // Load an existing user by ID
        User firstUser = em.find(User.class, 1L);
// Delete the user along with its posts
        em.getTransaction().begin();
        for (Post post : firstUser.getPosts())
            em.remove(post);
        em.remove(firstUser);
        em.getTransaction().commit();
        System.out.println("Deleted existing user #" +
                firstUser.getId());
    }

    private static void modifyUser(EntityManager em) {
        // Load an existing user by ID
        User firstUser = em.find(User.class, 1L);
        // Modify the User
        firstUser.setPasswordHash("" + new Date().getTime());
        firstUser.setFullName(firstUser.getFullName() + "2");
        // Persist pending changes
        em.getTransaction().begin();
        em.persist(firstUser);
        em.getTransaction().commit();
        System.out.println(
                "Edited existing user #" + firstUser.getId());
    }

    private static void queryPeshoPosts(EntityManager em) {
        Query peshoPosts =
                em.createQuery(
                        "FROM Post p JOIN FETCH p.author " +
                                "WHERE p.author.username " +
                                "LIKE CONCAT(:username, '%') ")
                        .setParameter("username", "pesho");
        List<Post> posts = peshoPosts.getResultList();
        for (Post post : posts) {
            System.out.println(post);
        }
    }

    private static void queryPosts(EntityManager em) {
        Query allPostsQuerySlow = em.createQuery(
                "SELECT p FROM Post p");
        Query allPostsQuery = em.createQuery(
                "SELECT p FROM Post p JOIN FETCH p.author");
        List<Post> posts =
                allPostsQuery.getResultList();
        posts.forEach(System.out::println);
    }

    private static void addUserAndPosts(EntityManager em) {
        em.getTransaction().begin();
        User newUser = new User();
        newUser.setUsername("pesho" + new Date().getTime());
        newUser.setPasswordHash("pass12345");
        newUser.setFullName("P.Petrov");
        em.persist(newUser);
        System.out.println("Created new user #" + newUser.getId());
        for (int i = 1; i <= 10; i++) {
            Post newPost = new Post();
            newPost.setTitle("Post Title " + i);
            newPost.setBody("<p>Body" + i + "</p>");
            newPost.setAuthor(newUser);
            em.persist(newPost);
            System.out.println("Created new post #" + newPost.getId());
        }
        em.getTransaction().commit();
    }

    private static void addPesho(EntityManagerFactory emf, EntityManager em) {
        try {
            User newUser = new User();
            newUser.setUsername("pesho");
            em.getTransaction().begin();
            em.persist(newUser);
            em.getTransaction().commit();
            System.out.println("Created new user #" + newUser.getId());
        } finally {
            em.close();
            emf.close();
        }
    }
}
