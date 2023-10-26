namespace WebCoreMenuDemo.Models
{
    public class Application
    {
        public string application_id { get; set; }
        public string application_code { get; set; }
        public string application_description { get; set; }
        public object application_link { get; set; }
        public string application_method { get; set; }
        public string application_status { get; set; }
        public string application_image { get; set; }
        public string create_id { get; set; }
        public object create_dt { get; set; }
        public object upd_dt { get; set; }
        public string upd_id { get; set; }
    }
    public class ROOT_APPLICATION
    {
        public string token { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string lastname { get; set; }
        public string position { get; set; }
        public string position_description { get; set; }
        public string security_level { get; set; }
        public List<Application> application { get; set; }
    }
}
