/* 
 *	Copyright (C) 2006 Team MediaPortal
 *	http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */
#pragma once

#include "sectiondecoder.h"
#include "PmtParser.h"
#include "sdtParser.h"
#include "NitDecoder.h"
#include "channelinfo.h"
#include "VirtualChannelTableParser.h"
//#include "conditionalAccess.h"
#include <vector>
#include <map>
using namespace std;

class CPatParser : public CSectionDecoder, public IPmtCallBack, public ISdtCallBack, public IAtscCallback
{
public:
  CPatParser(void);
  virtual ~CPatParser(void);

	void	OnTsPacket(byte* tsPacket);
  void  Reset();
	void  OnNewSection(CSection& section);

  BOOL        IsReady();
  int         Count();
  bool        GetChannel(int index, CChannelInfo& info);
  void        Dump();
	//void				SetConditionalAccess(CConditionalAccess* access);
	void				OnPmtReceived(int pmtPid);
  void        OnPidsReceived(CPidTable info);
	void        OnSdtReceived(CChannelInfo sdtInfo);
  void        OnChannel(CChannelInfo info);
private:
	void				               UpdateHwPids();
  CVirtualChannelTableParser m_vctParser;
  CSdtParser                 m_sdtParser;
  CSdtParser                 m_sdtParserOther;
	CNITDecoder                m_nitDecoder;
  void                       CleanUp();
	//CConditionalAccess* m_pConditionalAccess;

  map<int,CPmtParser*> m_mapPmtParsers;
  typedef map<int,CPmtParser*> ::iterator itPmtParser;
  map<int,CChannelInfo> m_mapChannels;
  typedef map<int,CChannelInfo> ::iterator itChannels;
  bool m_bDumped;
};
