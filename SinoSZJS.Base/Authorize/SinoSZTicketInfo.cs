using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace SinoSZJS.Base.Authorize
{
        public class SinoSZTicketInfo: ILogicalThreadAffinative
        {
                string _ticket = "";
                string _name = "";
                string _addr = "";

                public string Ticket
                {
                        get { return _ticket; }
                        set { _ticket = value;}
                }

                public string Name
                {
                        get { return _name; }
                        set { _name = value; }
                }

                public string Address
                {
                        get { return _addr; }
                        set { _addr = value; }
                }

                public SinoSZTicketInfo()
                {
                }

                public SinoSZTicketInfo(string _uname, string _uaddr, string _uticket)
                {
                        _name = _uname;
                        _addr = _uaddr;
                        _ticket = _uticket;
                }
        }
}
