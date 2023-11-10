namespace WriterBlog.WebUI.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string NomalizeName { get; set; }

        public bool Exists { get; set; }
    }
}
