namespace HoLWeb.DataLayer.SkillBuilders
{
    public class BuildResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
