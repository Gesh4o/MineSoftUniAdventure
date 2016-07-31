import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import java.time.LocalDateTime;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("JPAExercise");
        EntityManager em = emf.createEntityManager();

        CriteriaBuilder cb = em.getCriteriaBuilder();
        try {
            listAllPosts(em, cb);
            listAllUsers(em, cb);

            listAllUsersOrdered(em, cb);
            listAllUsersOrderedByTwoColumns(em, cb);

            listAllAuthors(em, cb);
            listConcreteAuthor(em, cb);

            createNewPost(em);

            deletePost(em);

            updatePost(em);
        } finally {
            em.close();
            emf.close();
        }
    }

    private static void updatePost(EntityManager em) {
        Post post = em.find(Post.class, 34);
        post.setContent("New content");

        em.getTransaction().begin();
        em.persist(post);
        em.getTransaction().commit();
    }

    private static void deletePost(EntityManager em) {
        Post post = em.find(Post.class, 31);
        if (post != null) {
            if (post.getComments() != null) {
                post.getComments().clear();
            }

            if (post.getTags() != null) {
                post.getTags().clear();
            }
            em.remove(post);
            em.getTransaction().commit();
        }
    }

    private static void createNewPost(EntityManager em) {
        User user = em.find(User.class, 2);
        LocalDateTime date = LocalDateTime.now();
        Post post = new Post();
        post.setAuthor(user);
        post.setDate(date);
        post.setTitle("Titlee.");
        post.setContent("Can see.");

        em.getTransaction().begin();
        em.persist(post);
        em.getTransaction().commit();
    }

    private static void listAllPosts(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<Post> query = cb.createQuery(Post.class);
        Root<Post> root = query.from(Post.class);
        query.select(root);

        List<Post> posts = em.createQuery(query).getResultList();

        for (Post post :
                posts) {
            System.out.printf("Title: %s%nAuthor: %s%n", post.getTitle(), post.getAuthor());
        }
    }

    private static void listAllUsers(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<User> query = cb.createQuery(User.class);
        Root<User> root = query.from(User.class);


        query.select(root);

        List<User> users = em.createQuery(query).getResultList();

        for (User user :
                users) {
            System.out.printf("Id: %s%nName: %s%nUsername: %s%n", user.getId(), user.getFullname(), user.getUsername());
        }
    }

    private static void listAllUsersOrdered(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<User> query = cb.createQuery(User.class);
        Root<User> root = query.from(User.class);


        query.select(root);
        query.orderBy(cb.asc(root.get("username")));

        List<User> users = em.createQuery(query).getResultList();

        for (User user :
                users) {
            System.out.printf("Name: %s%nUsername: %s%n", user.getFullname(), user.getUsername());
        }
    }

    private static void listAllUsersOrderedByTwoColumns(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<User> query = cb.createQuery(User.class);
        Root<User> root = query.from(User.class);


        query.select(root);
        query.orderBy(cb.desc(root.get("username")), cb.desc(root.get("fullname")));

        List<User> users = em.createQuery(query).getResultList();

        for (User user :
                users) {
            System.out.printf("Name: %s%nUsername: %s%n", user.getFullname(), user.getUsername());
        }
    }

    private static void listAllAuthors(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<User> query = cb.createQuery(User.class);
        Root<User> root = query.from(User.class);


        query.select(root);
        query.where(cb.gt(cb.size(root.get("posts")), 0));

        List<User> users = em.createQuery(query).getResultList();

        for (User user :
                users) {
            System.out.printf("Name: %s%nUsername: %s%nCount: %d%n", user.getFullname(), user.getUsername(), user.getPosts().size());
        }
    }

    private static void listConcreteAuthor(EntityManager em, CriteriaBuilder cb) {
        CriteriaQuery<User> query = cb.createQuery(User.class);
        Root<User> root = query.from(User.class);


        query.select(root);
        query.where(cb.equal(root.join("posts").get("id"), 4)).select(root);

        List<User> users = em.createQuery(query).getResultList();

        for (User user :
                users) {
            System.out.printf("Name: %s%nUsername: %s%n", user.getFullname(), user.getUsername());
        }
    }

}
