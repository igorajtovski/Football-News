using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace euro1.Models
{
    public partial class ImageGallery
    {
        [Key]
        public int ImageID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        [Required(ErrorMessage = "Please select file")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}