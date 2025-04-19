using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hx.ArchivaFlow.Domain
{
    /// <summary>
    /// 元数据值对象
    /// </summary>
    public class Metadata : AuditedEntity
    {
        /// <summary>
        /// 元数据键（唯一标识）
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// 元数据值
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// 数据类型（用于解析值类型）
        /// </summary>
        public MetadataDataType DataType { get; private set; }

        /// <summary>
        /// 关联的档案ID
        /// </summary>
        public Guid ArchiveId { get; private set; }

        /// <summary>
        /// 导航属性：所属档案
        /// </summary>
        public virtual Archive Archive { get; private set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public double Order { get; private set; }

        /// <summary>
        /// 元数据标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 是否静态
        /// </summary>
        public bool IsStatic { get; private set; }

        /// <summary>
        /// 元数据导航属性（扩展预留）
        /// </summary>
        public string? NavigationProperty { get; private set; }

        // 赋值构造函数
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public Metadata(
            string key,
            string value,
            MetadataDataType dataType,
            Guid archiveId,
            string? navigationProperty,
            double order,
            string title,
            bool isStatic)
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
            Key = key;
            Value = value;
            DataType = dataType;
            ArchiveId = archiveId;
            NavigationProperty = navigationProperty;
            Order = order;
            Title = title;
            IsStatic = isStatic;
        }
        public void SetKey(string key)
        {
            Key = key;
        }

        public void SetValue(string value)
        {
            Value = value;
        }

        public void SetDataType(MetadataDataType dataType)
        {
            DataType = dataType;
        }

        public void SetArchiveId(Guid archiveId)
        {
            ArchiveId = archiveId;
        }

        public void SetNavigationProperty(string? navigationProperty)
        {
            NavigationProperty = navigationProperty;
        }

        public void SetOder(double oder)
        {
            Order = oder;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetIsStatic(bool isStatic)
        {
            IsStatic = isStatic;
        }

        public void Update(string value, MetadataDataType dataType, string? navigationProperty, double order, string title)
        {
            if (!string.Equals(Value, value))
            {
                Value = value;
            }
            if (DataType != dataType)
            {
                DataType = dataType;
            }
            if (!string.Equals(NavigationProperty, navigationProperty))
            {
                NavigationProperty = navigationProperty;
            }
            if (Order != order)
            {
                Order = order;
            }
            if (!string.Equals(Title, title))
            {
                Title = title;
            }
        }

        public void ValidateDataType()
        {
            switch (DataType)
            {
                case MetadataDataType.Number:
                    if (!double.TryParse(Value, out _))
                        throw new UserFriendlyException($"[{Key}]字段类型{DataType}与字段值{Value}不匹配！");
                    break;
                case MetadataDataType.Date:
                    if (!DateTime.TryParse(Value, out _))
                        throw new UserFriendlyException($"[{Key}]字段类型{DataType}与字段值{Value}不匹配！");
                    break;
                case MetadataDataType.Boolean:
                    if (!bool.TryParse(Value, out _))
                        throw new UserFriendlyException($"[{Key}]字段类型{DataType}与字段值{Value}不匹配！");
                    break;
            }
        }

        public override object?[] GetKeys() => [ArchiveId, Key];
    }
}