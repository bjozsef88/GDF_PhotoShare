using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    [MetadataType(typeof(PhotoMetaData))]
    public partial class Photo
    {
    }

    public class PhotoMetaData
    {
        [Required(ErrorMessage = "Az IP cím megadása kötelező!")]
        [Display(Name = "IP Cím")]
        public string IpAddress { get; set; }
        [Required(ErrorMessage = "Az e-mail cím megadása kötelező!")]
        [Display(Name = "E-mail cím")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A fénykép címének megadása kötelező!")]
        [Display(Name = "Fénykép címe")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A feltöltő nevét kötelező megadni!")]
        [Display(Name = "Feltöltő neve")]
        public string Name { get; set; }
    }
}