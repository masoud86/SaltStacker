using SaltStacker.Application.ViewModels.Base;

namespace SaltStacker.Application.ViewModels.Membership.File;

public class UserFiles : Pagination
{
    public UserFiles() : base("UploadTime") => Columns = new Dictionary<string, string> {
            {"UploadTime", "Upload Time"}
        };

    public List<UserFileDto> Items { get; set; }
}

public class UserFileFilters : Pagination
{
    public UserFileFilters() : base("UploadTime")
    {

    }
}
