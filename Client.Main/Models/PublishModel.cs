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

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Code { get; set; }

        public long EntityId { get; set; }
    }
}