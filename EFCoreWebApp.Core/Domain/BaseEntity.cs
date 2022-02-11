using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreWebApp.Core.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; } 
    }
}
