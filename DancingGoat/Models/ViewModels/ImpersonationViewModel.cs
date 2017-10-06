using System;
using System.Linq;
using KenticoCloud.Personalization;

namespace DancingGoat.Models.ViewModels
{
    public class ImpersonationViewModel
    {
        public Segment[] Segments { get; set; }

        public string GetSegmentString()
        {
            return String.Join(", ", Segments.Select(x => x.Name));
        }

        public bool IsInAnySegment()
        {
            return Segments == null || Segments.Any();
        }
    }
}