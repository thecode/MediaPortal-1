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

using System.Collections.Generic;

#pragma warning disable 108

namespace MediaPortal.Configuration.Sections
{
  public class MusicViews : BaseViewsNew
  {
    private string[] selections = new string[]
                                    {
                                      "Path",
                                      "Artist",
                                      "AlbumArtist",
                                      "Album",
                                      "Genre",
                                      "Title",
                                      "Composer",
                                      "Conductor",
                                      "Year",
                                      "Track#",
                                      "NumTracks",
                                      "Timesplayed",
                                      "Rating",
                                      "Favorites",
                                      "DateAdded",
                                      "DateLastPlayed",
                                      "Disc#",
                                      "NumDiscs",
                                      "Duration",
                                      "ResumeAt",
                                      "Lyrics",
                                      "Comment",
                                      "FileType",
                                      "FullCodec",
                                      "BitRateMode",
                                      "BPM",
                                      "Bitrate",
                                      "Channels",
                                      "SampleRate",
                                      "ArtistIndex",
                                      "AlbumArtistIndex",
                                      "ComposerIndex",
                                      "ConductorIndex",
                                      "GenreIndex",
                                    };

    private string[] viewsAs = new string[]
                                 {
                                   "List",
                                   "Icons",
                                   "Big Icons",
                                   "Filmstrip",
                                   "Cover Flow",
                                   "Albums",
                                 };

    private string[] sortBy = new string[]
                                {
                                  "Name",
                                  "Date",
                                  "Year",
                                  "Size",
                                  "Track",
                                  "Duration",
                                  "Title",
                                  "Artist",
                                  "Album",
                                  "Filename",
                                  "Rating",
                                  "Disc#",
                                  "Composer",
                                  "Times Played",
                                };

    public MusicViews()
      : this("Music Views")
    {}

    public MusicViews(string name)
      : base(name) {}

    public override void LoadSettings()
    {
      base.LoadSettings("Music", selections, viewsAs, sortBy);
    }

    public override void SaveSettings()
    {
      base.SaveSettings("Music");
    }

    public override void OnSectionActivated()
    {
      base.Section = "Music";
      base.OnSectionActivated();
    }
  }
}