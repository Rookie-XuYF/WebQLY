using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
namespace WebQLY.Models
{
    [Table("T_SYS_User")]
    [Display(Name = "T_SYS_User")]
    public class T_SYS_User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "自增ID")]
        [Description("自增ID")]
        public int ID { get; set; }//主键
        public string UserName { get; set; }


        public string Password { get; set; }

        public string Name {  get; set; }


    }
}