using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace RiidePood
{
    public interface IMuugitoode
{
    double ArvutaLopphind();
    string KuvaInfo();
    int GetKogus();
    void VahendaKogus(int kogus);
}
}