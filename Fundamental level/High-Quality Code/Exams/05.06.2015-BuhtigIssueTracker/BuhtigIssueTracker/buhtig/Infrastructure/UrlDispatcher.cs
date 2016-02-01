namespace BuhtigIssueTracker.Infrastructure
{
    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Enums;

    public class UrlDispatcher
    {
        public UrlDispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public UrlDispatcher() : this(new IssueTracker())
        {
        }

        public IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    string registerUserView = this.Tracker.RegisterUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"],
                        endpoint.Parameters["confirmPassword"]);

                    return registerUserView;
                case "LoginUser":
                    string loginUserView = this.Tracker.LoginUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"]);

                    return loginUserView;
                case "LogoutUser":
                    string logoutUserView = this.Tracker.LogoutUser();

                    return logoutUserView;
                case "CreateIssue":
                    string createIssueView = this.Tracker.CreateIssue(
                        endpoint.Parameters["title"],
                        endpoint.Parameters["description"],
                        (IssuePriority)System.Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true),
                        endpoint.Parameters["tags"].Split('|'));

                    return createIssueView;
                case "RemoveIssue":
                    string removeIssueView = this.Tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));

                    return removeIssueView;
                case "AddComment":
                    string addCommentView = this.Tracker.AddComment(
                        int.Parse(endpoint.Parameters["id"]),
                        endpoint.Parameters["text"]);

                    return addCommentView;
                case "MyIssues":
                    string myIssuesView = this.Tracker.GetMyIssues();

                    return myIssuesView;
                case "MyComments":
                    string myCommentsView = this.Tracker.GetMyComments();

                    return myCommentsView;
                case "Search":
                    string searchView = this.Tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));

                    return searchView;
                default:
                    string defaultView = $"Invalid action: {endpoint.ActionName}";

                    return defaultView;
            }
        }
    }
}
