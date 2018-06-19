using System;

namespace Phoenix.Models.Interface
{
    public interface IModel
    {
        Guid Id { get; set; }
        bool Archived { get; set; }
        DateTime LastUpdated { get; set; }
        string LastUpdateBy { get; set; }
    }
}