using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Interfaces.Repositories;
using YanAlves.yNote.Domain.Services.Base;

namespace YanAlves.yNote.Domain.Services
{
    public class TagService : ServiceBase<Tag>
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository) : base(tagRepository)
        {
            this._tagRepository = tagRepository;
        }
    }
}
