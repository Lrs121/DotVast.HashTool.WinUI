using System.Collections.ObjectModel;
using System.Text;

using DotVast.HashTool.WinUI.Helpers;
using DotVast.HashTool.WinUI.Services.Hash;

namespace DotVast.HashTool.WinUI.Models;

public sealed partial class HashTask : ObservableObject
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private DateTime _dateTime;

    [ObservableProperty]
    private TimeSpan _elapsed;

    [ObservableProperty]
    private HashTaskMode _mode = HashTaskMode.File;

    [ObservableProperty]
    private string _content = string.Empty;

    [ObservableProperty]
    private Encoding? _encoding;

    [ObservableProperty]
    private HashTaskState? _state;

    /// <summary>
    /// 单结果 (文件, 文本).
    /// </summary>
    [ObservableProperty]
    private HashResult? _result;

    /// <summary>
    /// 多结果.
    /// 在“文件, 文本”模式下，设置值为 new() { Result }.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<HashResult>? _results;

    public IList<Hash> SelectedHashs { get; set; } = Array.Empty<Hash>();

    partial void OnResultChanged(HashResult? value)
    {
        if (Mode == HashTaskMode.Folder || value == null)
        {
            return;
        }

        if (Results != null)
        {
            Results.Clear();
            Results.Add(value);
        }
        else
        {
            Results = new() { value };
        }
    }
}

public sealed class HashTaskState : GenericEnum<string>
{
    /// <summary>
    /// 等待中.
    /// </summary>
    public static HashTaskState Waiting { get; } = new(Localization.HashTaskState_Waiting);

    /// <summary>
    /// 计算中.
    /// </summary>
    public static HashTaskState Working { get; } = new(Localization.HashTaskState_Working);

    /// <summary>
    /// 已完成.
    /// </summary>
    public static HashTaskState Completed { get; } = new(Localization.HashTaskState_Completed);

    /// <summary>
    /// 任务取消.
    /// </summary>
    public static HashTaskState Canceled { get; } = new(Localization.HashTaskState_Canceled);

    /// <summary>
    /// 任务中止(错误/意外).
    /// </summary>
    public static HashTaskState Aborted { get; } = new(Localization.HashTaskState_Aborted);

    private HashTaskState(string name) : base(name) { }
}

public sealed class HashTaskMode : GenericEnum<string>
{
    /// <summary>
    /// 文件.
    /// </summary>
    public static HashTaskMode File { get; } = new(Localization.HashTaskMode_File);

    /// <summary>
    /// 文件夹.
    /// </summary>
    public static HashTaskMode Folder { get; } = new(Localization.HashTaskMode_Folder);

    /// <summary>
    /// 文本.
    /// </summary>
    public static HashTaskMode Text { get; } = new(Localization.HashTaskMode_Text);

    private HashTaskMode(string name) : base(name) { }
}
