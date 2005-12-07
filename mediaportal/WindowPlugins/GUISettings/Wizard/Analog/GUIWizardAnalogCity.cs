using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using MediaPortal.GUI.Library;

namespace WindowPlugins.GUISettings.Wizard.Analog
{
  /// <summary>
  /// Summary description for GUIWizardAnalogCity.
  /// </summary>
  public class GUIWizardAnalogCity : GUIWindow, IComparer<GUIListItem>
  {
    [SkinControlAttribute(23)]
    protected GUIButtonControl btnManual = null;
    [SkinControlAttribute(27)]
    protected GUIButtonControl btnSkip = null;
    [SkinControlAttribute(26)]
    protected GUILabelControl lblCountry = null;
    [SkinControlAttribute(24)]
    protected GUIListControl listCities = null;
    [SkinControlAttribute(25)]
    protected GUIButtonControl btnBack = null;

    public GUIWizardAnalogCity()
    {
      GetID = (int)GUIWindow.Window.WINDOW_WIZARD_ANALOG_CITY;
    }

    public override bool Init()
    {
      return Load(GUIGraphicsContext.Skin + @"\wizard_tvcard_analog_city.xml");
    }
    protected override void OnPageLoad()
    {
      base.OnPageLoad();
      LoadCities();
    }

    void LoadCities()
    {
        string country = GUIPropertyManager.GetProperty("#WizardCountry");
        bool internetAccess = bool.Parse(GUIPropertyManager.GetProperty("#InternetAccess"));

      lblCountry.Label = country;

      if (internetAccess)
      {
          listCities.Clear();
          XmlDocument doc = new XmlDocument();
          doc = new XmlDocument();
          doc.Load("http://mediaportal.sourceforge.net/tvsetup/setup.xml");
          XmlNodeList countries = doc.DocumentElement.SelectNodes("/mediaportal/country");
          foreach (XmlNode nodeCountry in countries)
          {
              XmlNode nodeCountryName = nodeCountry.Attributes.GetNamedItem("name");
              if (country == nodeCountryName.Value)
              {
                  XmlNodeList cities = nodeCountry.SelectNodes("city");
                  foreach (XmlNode nodeCity in cities)
                  {
                      XmlNode listCitiesName = nodeCity.Attributes.GetNamedItem("name");
                      XmlNode urlName = nodeCity.SelectSingleNode("analog");

                      GUIListItem item = new GUIListItem();
                      item.IsFolder = false;
                      item.Label = listCitiesName.Value;
                      item.Path = urlName.InnerText;
                      listCities.Add(item);
                  }
              }
          }
          if (listCities.Count == 0)
          {
              GUIControl.FocusControl(GetID, btnManual.GetID);
              GUIListItem item = new GUIListItem();
              item.IsFolder = false;
              item.Label = "No Cities Found";
              item.Path = "none";
              listCities.Add(item);
          }

          listCities.Sort(this);
      }
    }
    protected override void OnClicked(int controlId, GUIControl control, MediaPortal.GUI.Library.Action.ActionType actionType)
    {
      if (control == listCities)
      {
        GUIListItem item = listCities.SelectedListItem;
        DoScan(item.Label, item.Path);
        GUIWindowManager.ActivateWindow((int)GUIWindow.Window.WINDOW_WIZARD_ANALOG_IMPORTED);
        return;
      }
      if (control == btnManual)
      {
          GUIWindowManager.ActivateWindow((int)GUIWindow.Window.WINDOW_WIZARD_ANALOG_TUNE); //MANUAL_TUNE);
      }
      if (control == btnSkip)
      {
          GUIPropertyManager.SetProperty("#Wizard.Analog.Done", "yes");
          GUIWindowManager.ActivateWindow((int)GUIWindow.Window.WINDOW_WIZARD_EPG_SELECT);
      }
      if (btnBack == control) GUIWindowManager.ShowPreviousWindow();
      base.OnClicked(controlId, control, actionType);
    }

    void DoScan(string city, string url)
    {
      GUIPropertyManager.SetProperty("#WizardCity", city);
      GUIPropertyManager.SetProperty("#WizardCityUrl", url);
    }
    #region IComparer Members

    public int Compare(GUIListItem item1, GUIListItem item2)
    {
      return String.Compare(item1.Label, item2.Label);
    }

    #endregion
  }
}
