namespace WebAPI.Dtos
{
    public class PhotoDto
    {
        public string ImageUrl{ get; set; }
        public string Publicid { get; set; }

        public bool IsPrimary { get; set; }
    }
}
