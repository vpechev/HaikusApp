namespace Client.Main.Models
{
    public class PublishModel
    {
        public PublishModel()
        {
        }

        public PublishModel(string controllerName, string actionName)
        {
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        public PublishModel(string controllerName, string actionName, long entityId)
            : this(controllerName, actionName)
        {
            this.EntityId = entityId;
        }

        public PublishModel(string controllerName, string actionName, int skip, int take)
            : this(controllerName, actionName)
        {
            this.Skip = skip;
            this.Take = take;
        }

        public int Skip { get; set; }
        public int Take { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Code { get; set; }

        public long EntityId { get; set; }
    }
}