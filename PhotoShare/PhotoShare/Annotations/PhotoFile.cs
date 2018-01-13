using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    [MetadataType(typeof(PhotoFileMetaData))]
    public partial class PhotoFile
    {
    }

    public class PhotoFileMetaData
    {
        
    }
}