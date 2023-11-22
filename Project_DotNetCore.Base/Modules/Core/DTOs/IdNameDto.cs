namespace Project_DotNetCore.Base.Modules.Core.DTOs
{
    public class IdNameDto<T> where T : struct 
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }

    public class IdNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IdTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class IdNameLongDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class IdNameStringDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class IdNameGroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

    }

    public class IdCategoryIdStringDto
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
    }

    public class IdOtherIdAndNameDto
    {
        public int Id { get; set; }
        public string OtherId { get; set; }
        public string Name { get; set; }
    }
}