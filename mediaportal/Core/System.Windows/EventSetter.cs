#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

namespace System.Windows
{
  public class EventSetter : SetterBase
  {
    #region Constructors

    public EventSetter() {}

    public EventSetter(RoutedEvent routedEvent, Delegate handler)
    {
      _event = routedEvent;
      _handler = handler;
    }

    #endregion Constructors

    #region Properties

    public RoutedEvent Event
    {
      get { return _event; }
      set { _event = value; }
    }

    public bool HandledEventsToo
    {
      get { return _isHandledEventsToo; }
      set { _isHandledEventsToo = value; }
    }

    public Delegate Handler
    {
      get { return _handler; }
      set { _handler = value; }
    }

    #endregion Properties

    #region Fields

    private RoutedEvent _event = null;
    private bool _isHandledEventsToo = false;
    private Delegate _handler = null;

    #endregion Fields
  }
}