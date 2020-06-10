using System.Collections.Generic;

namespace InfrastuctureLayer.Models
{
    public class Fareremark
    {
        public List<Remark> Remarks;

        public override string ToString()
        {
            var result = "";
            foreach (var remark in Remarks)
            {
                result += $"{remark} \n";
            }

            return result;
        }
    }
}