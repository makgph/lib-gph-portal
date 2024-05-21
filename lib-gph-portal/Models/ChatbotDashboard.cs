using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using Umbraco.Core.Persistence.DatabaseAnnotations;
using Umbraco.Core.Persistence;

namespace sa.gov.libgph.Models
{
    [System.Web.DynamicData.TableName("chatbot_dashboard")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class ChatbotDashboard
    {
        [Key]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }
        public string SessionId { get; set; }

        public DateTime InqueryDate { get; set; }
    }
}