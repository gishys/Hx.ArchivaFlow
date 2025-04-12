﻿using System.Collections.ObjectModel;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchiveCatalogueDto
    {
        /// <summary>
        /// 业务类型Id
        /// </summary>
        public required string Reference { get; set; }
        /// <summary>
        /// 业务类型标识
        /// </summary>
        public int ReferenceType { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>
        public required string CatalogueName { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public int SequenceNumber { get; set; }
        /// <summary>
        /// Parent Id
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 是否必收
        /// </summary>
        public required bool IsRequired { get; set; }
        /// <summary>
        /// 附件数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 静态标识
        /// </summary>
        public bool IsStatic { get; set; }
        /// <summary>
        /// 是否核验
        /// </summary>
        public bool IsVerification { get; set; }
        /// <summary>
        /// 核验通过
        /// </summary>
        public bool VerificationPassed { get; set; }
        /// <summary>
        /// 子文件夹
        /// </summary>
        public ICollection<ArchiveCatalogueDto>? Children { get; set; }
        /// <summary>
        /// 附件文件集合
        /// </summary>
        public Collection<ArchiveFileDto>? Files { get; set; }
    }
}
