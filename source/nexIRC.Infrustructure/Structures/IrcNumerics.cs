namespace nexIRC.Infrustructure.Structures {
    public enum IrcNumerics {
        sNOTHING = 0,
        sRPL_WELCOME = 1,
        //  The first message sent after client  . The text used varies widely
        //  The server sends Replies 001 to 004 to a user upon successful registration.
        //  RFC2812:                  :Welcome to the Internet Relay Network <nick>!<user>@<host>
        //  BAHAMUT:                  :%s 001 %s :Welcome to the DALnet IRC Network %s!%s@%s
        //  HYBRID:                   :%s 001 %s :Welcome to the Internet Relay Network %s
        //  UNREAL:                   :%s 001 %s :Welcome to the %s IRC Network %s!%s@%s
        //  IRC2:                     :Welcome to the Internet Relay Network %s
        //  IRCU:                     :Welcome to the Internet Relay Network%s%s, %s
        sRPL_YOURHOST = 2,
        //  Part of the post-registration greeting. Text varies widely
        //  The server sends Replies 001 to 004 to a user upon successful registration.
        //  RFC2812:                  :Your host is <servername>, running version <version>
        //  BAHAMUT/HYBRID/UNREAL:    :%s 002 %s :Your host is %s, running version %s
        //  IRC2/IRCU:                :Your host is %s, running version %s
        sRPL_CREATED = 3,
        //  Part of the post-registration greeting. Text varies widely
        //  The server sends Replies 001 to 004 to a user upon successful registration.
        //  RFC2812:                  :This server was created <date>
        //  BAHAMUT/HYBRID/UNREAL:    :%s 003 %s :This server was created %s
        //  IRC2/IRCU                 :This server was created %s
        sRPL_MYINFO = 4,
        //  Part of the post-registration greeting
        //  RFC2812:                  <server_name> <version> <user_modes> <chan_modes>
        //  KINEIRCD:                 <server_name> <version> <user_modes> <chan_modes> <channel_modes_with_params> <user_modes_with_params> <server_modes> <server_modes_with_params>
        //  BAHAMUT:                  :%s 004 %s %s %s oOiwscrkKnfydaAbgheFxXj biklLmMnoprRstvc
        //  HYBRID:                   :%s 004 %s %s %s oOiwszcrkfydnxb biklmnopstve
        //  IRC2:                     %s %s aoOirw abeiIklmnoOpqrstv
        //  IRCU:                     %s %s dioswkgx biklmnopstvr bklov
        //  UNREAL:                   :%s 004 %s %s %s %s %s
        //sRPL_BOUNCE = 5 '(DEPRECIATED)
        //  Sent by the server to a user to suggest an alternative server, sometimes used when the connection is refused because the server is already full. Also known as RPL_SLINE (AUSTHEX), and RPL_REDIR Also see #010.
        //  RFC2812:                  :Try server <server_name>, port <port_number>
        sRPL_ISUPPORT = 5,
        //(CONFLICTING)
        //IRCNET, BAHAMUT, IRCU:      :irc.example.org 005 nick PREFIX=(ov)@+ CHANTYPES=#& :are supported by this server
        //  PREFIX: A list of channel modes a person can get and the respective prefix a channel or nickname will get in case the person has it. The order of the modes goes from most powerful to least powerful. Those prefixes are shown in the output of the WHOIS, WHO and NAMES command.
        //    PREFIX=(ov)@+ (IRCNET, BAHAMUT, IRCU)
        //    PREFIX=(ohv)@%+ (HYBRID)
        //  CHANTYPES: The supported channel prefixes.
        //    CHANTYPES=#& (IRCU)
        //    CHANTYPES=#&!+ (IRCNET)
        //    CHANTYPES=# (BAHAMUT)
        //    CHANTYPES=#& (HYBRID)
        //  CHANMODES: This is a list of channel modes according to 4 types.
        //    A = Mode that adds or removes a nick or address to a list. Always has a parameter.
        //    B = Mode that changes a setting and always has a parameter.
        //    C = Mode that changes a setting and only has a parameter when set.
        //    D = Mode that changes a setting and never has a parameter.
        //    Note: Modes of type A return the list when there is no parameter present.
        //    Note: Some clients assumes that any mode not listed is of type D.
        //    Note: Modes in PREFIX are not listed but could be considered type B.
        //    CHANMODES=b,k,l,imnpstr (IRCU)
        //    CHANMODES=b,k,l,ciLmMnOprRst (BAHAMUT)
        //    CHANMODES=beI,k,l,imnpstaqr (IRCNET)
        //    CHANMODES=beI,k,l,imnpsta (HYBRID)
        //  MODES: Maximum number of channel modes with parameter allowed per MODE command.
        //    MODES=3 (IRCNET)
        //    MODES=4 (HYBRID)
        //    MODES=6 (IRCU, BAHAMUT)
        //  MAXCHANNELS: Maximum number of channels allowed to join. This has been replaced by CHANLIMIT.
        //    MAXCHANNELS=10 (IRCNET, HYBRID, BAHAMUT)
        //    MAXCHANNELS=20 (IRCU)
        //  CHANLIMIT: Maximum number of channels allowed to join by channel prefix.
        //    CHANLIMIT=#&!+:10 (IRCNET)
        //  NICKLEN: Maximum nickname length.
        //    NICKLEN=9 (IRCNET, IRCU, HYBRID)
        //    NICKLEN=30 (BAHAMUT)
        //  MAXBANS: Maximum number of bans per channel. Note: This has been replaced by MAXLIST. 
        //    MAXBANS=30 (IRCNET)
        //    MAXBANS=25 (HYBRID)
        //    MAXBANS=45 (IRCU)
        //    MAXBANS=100 (BAHAMUT)
        //  MAXLIST: Maximum number entries in the list per mode.
        //    MAXLIST=beI:30 (IRCNET)
        //  NETWORK: The IRC network name.
        //    NETWORK=EFnet (HYBRID)
        //    NETWORK=IRCNET (IRCNET)
        //    NETWORK=UnderNet (IRCU)
        //    NETWORK=DALnet (BAHAMUT)
        //  EXCEPTS: The server support ban exceptions (e mode).
        //    EXCEPTS=e
        //  INVEX: The server support invite exceptions (+I mode).
        //    INVEX=I
        //  WALLCHOPS: The server supports messaging channel operators (NOTICE @#channel)
        //    Note: This has been replaced by STATUSMSG.
        //    IRCU also supports a WALLCHOPS command?
        //    Note: IRCU didn't support voiced persons because it conflicted with +channels. They removed the +channels.
        //    Note: HYBRID supports everything in PREFIX
        //    Note: HYBRID 6 and IRCU don't support it with PRIVMSG, HYBRID 7 does. 
        //    WALLCHOPS
        //  WALLVOICES: Notice to +#channel goes to all voiced persons.
        //    WALLVOICES
        //  STATUSMSG: The server supports messaging channel member who have a certain status or higher. The status is one of the letters from PREFIX.
        //    STATUSMSG=+@
        //  CASEMAPPING: 
        //    Case mapping used for nick- and channel name comparing. Current possible values:
        //    ascii: The chars [a-z] are lowercase of [A-Z].
        //    rfc1459: ascii with additional {}|~ the lowercase of []\^.
        //    strict-rfc1459: ascii with additional {}| the lowercase of []\.
        //    Note: RFC1459 forgot to mention the ~ and ^ although in all known implementations those are considered equivalent too. 
        //    CASEMAPPING=rfc1459 (IRCU, HYBRID, IRCNET)
        //    CASEMAPPING=ascii (BAHAMUT)
        //  ELIST: The server supports extentions for the LIST command. The tokens specify which extention are supported.
        //    M = mask search,
        //    N = !mask search
        //    U = usercount search (< >)
        //    C = creation time search (C< C>)
        //    T = topic search (T< T>)
        //  TOPICLEN: Maximum topic length.
        //    TOPICLEN=80 (IRCNET)
        //    TOPICLEN=120 (HYBRID)
        //    TOPICLEN=160 (IRCU)
        //    TOPICLEN=307 (BAHAMUT)
        //  KICKLEN: Maximum kick comment length.
        //    KICKLEN=80 (IRCNET)
        //    KICKLEN=120 (HYBRID)
        //    KICKLEN=160 (IRCU)
        //    KICKLEN=307 (BAHAMUT)
        //  CHANNELLEN: Maximum channel name length.
        //    CHANNELLEN=50 (IRCNET)
        //  CHIDLEN: Channel ID length for !channels (5 by default). See  RFC 2811 for more information.
        //    Note: This has been replaced by IDCHAN 
        //    CHIDLEN=5
        //  IDCHAN: The ID length for channels with an ID. The prefix says for which channel type it is, and the number how long it is.
        //    IDCHAN=!:5
        //  STD: The standard which the implementation is using.
        //    STD=i-d(03)
        //  SILENCE: The server support the SILENCE command. The number is the maximum number of allowed entries in the list.
        //    SILENCE=15 (IRCU)
        //    SILENCE=10 (BAHAMUT)
        //  RFC2812: Server supports  RFC 2812 features.
        //    RFC2812 
        //  PENALTY: Server gives extra penalty to some commands instead of the normal 2 seconds per message and 1 second for every 120 bytes in a message.
        //    PENALTY
        //  FNC: Forced nick changes: The server may change the nickname without the client sending a NICK message.
        //    FNC
        //  SAFELIST: The LIST is sent in multiple iterations so send queue won't fill and kill the client connection.
        //    SAFELIST
        //  AWAYLEN: AWAYLEN=160 (IRCU)
        //    AWAYLEN
        //  NOQUIT: Isn't this server to server feature, nothing to do with clients?
        //    NOQUIT 
        //  USERIP: The USERIP command exists.
        //    USERIP
        //  CPRIVMSG: The CPRIVMSG command exists, used for mass messaging people in specified channel (CPRIVMSG channel nick,nick2,... :text)
        //    CPRIVMSG channel nick,nick2,... :text
        //  CNOTICE: The CNOTICE command exists, just like CPRIVMSG
        //    CNOTICE
        //  MAXNICKLEN: Maximum length of nicks the server will send to the client?
        //    MAXNICKLEN
        //  MAXTARGETS: Maximum targets allowed for PRIVMSG and NOTICE commands
        //    MAXTARGETS=4 (HYBRID)
        //  KNOCK: The KNOCK command exists.
        //    KNOCK
        //  VCHANS: Server supports virtual channels. See  vchans.txt for more information.
        //    VCHANS
        //  WATCH: Maximum number of WATCHes allowed.
        //    WATCH=128 (BAHAMUT)
        //  WHOX: The WHO command uses WHOX protocol.
        //    WHOX
        //  CALLERID: The server supports server side ignores via the +g user mode. See  modeg.txt for more information.
        //    CALLERID
        //  ACCEPT: [Deprecated] The same as CALLERID.
        //    ACCEPT
        //  LANGUAGE: [Experimental] The server supports the LANGUAGE command. See the language document for more information.
        //    LANGUAGE=2,en,i-klingon
        sRPL_MAP = 6,
        //(DEPRECIATED)
        //  UNREAL:                   :%s 006 %s :%s%-*s(%d) %s
        sRPL_MAPEND = 7,
        //UNREAL (DEPRECIATED)
        //  :%s 007 %s :End of /MAP
        sRPL_SNOMASK = 8,
        //IRCU, UNREAL
        //  Server notice mask (hex)
        //  IRCU:                     %d :: Server notice mask (%#x)
        //  UNREAL:                   :%s 008 %s :Server notice mask (%s)
        //sRPL_STATMEMTOT = 9,
        //IRCU (Can't find information regaurding this)
        sRPL_BOUNCE_2 = 10,
        //  Sent to the client to redirect it to another server. Also known as RPL_REDIR
        //  RFC2812:                  <hostname> <port> :<info>
        //  UNREAL:                   :%s 010 %s %s %d :Please use this Server/Port instead
        //sRPL_YOURCOOKIE = 14
        //  HYBRID
        //sRPL_MAP2 = 15 '(DEPRECIATED)
        //  IRCU
        //sRPL_MAPMORE = 16 '(DEPRECIATED)
        //  IRCU
        //sRPL_MAPEND = 17 '(DEPRECIATED)
        //  IRCU 
        sRPL_PLEASEWAIT = 20,
        //(SEEN ON IRCNET)
        //  IRCNET:                   :Please wait while we establish a connection
        //sRPL_YOURID = 42
        //  IRCNET
        //sRPL_SAVENICK = 43
        //  Sent to the client when their nickname was forced to change due to a collision
        //  IRCNET:                   :<info>
        //sRPL_ATTEMPTINGJUNC = 50
        //  AIRCD
        //sRPL_ATTEMPTINGREROUTE = 51 'AIRCD
        //sRPL_REMOTEPROTOCTL = 105
        //  UNREAL:                   :%s 105 %s
        sRPL_TRACELINK = 200,
        //  RFC1459:                  Link <version & debug level> <destination> \ <next server>
        //  EXAMPLE:                  Link <version>[.<debug_level>] <destination> <next_server> [V<protocol_version> <link_uptime_in_seconds> <backstream_sendq> <upstream_sendq>]
        sRPL_TRACECONNECTING = 201,
        //  The RPL_TRACE* are all returned by the server in response to the TRACE message. How many are returned is dependent on the TRACE message and whether it was sent by an operator or not. There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the 'server handshake'.
        //  RFC1459:                  Try. <class> <server>
        sRPL_TRACEHANDSHAKE = 202,
        //  RFC1459:                  H.S. <class> <server>
        sRPL_TRACEUNKNOWN = 203,
        //  RFC1459:                  ???? <class> [<connection_address>]
        sRPL_TRACEOPERATOR = 204,
        //  RFC1459:                  Oper <class> <nick>
        sRPL_TRACEUSER = 205,
        //  RFC1459:                  User <class> <nick>
        sRPL_TRACESERVER = 206,
        //  RFC1459:                  Serv <class> <int>S <int>C <server> <nick!user|*!*>@<host|server> [V<protocol_version>]
        sRPL_TRACESERVICE = 207,
        //  RFC2812:                  Service <class> <name> <type> <active_type>
        sRPL_TRACENEWTYPE = 208,
        //  RFC1459:                  <newtype> 0 <client_name>
        sRPL_TRACECLASS = 209,
        //  RFC2812:                  Class <class> <count>
        sRPL_TRACERECONNECT = 210,
        //(DEPRECIATED)
        //  RFC2812
        //sRPL_STATS = 210
        //  Used instead of having multiple stats numerics
        //  AIRCD
        sRPL_STATSLINKINFO = 211,
        //  Reply to STATS
        //  RFC1459:                  <linkname> <sendq> <sent_msgs> <sent_bytes> <recvd_msgs> <rcvd_bytes> <time_open>
        sRPL_STATSCOMMANDS = 212,
        //  Reply to STATS
        //  RFC1459:                  <command> <count> [<byte_count> <remote_count>]
        sRPL_STATSCLINE = 213,
        //RFC1459
        //  Reply to STATS
        //  RFC1459:                  C <host> * <name> <port> <class>
        sRPL_STATSNLINE = 214,
        //(DEPRECIATED)
        //  Reply to STATS, Also known as RPL_STATSOLDNLINE (IRCU, UNREAL)
        //  RFC1459:                  N <host> * <name> <port> <class>
        sRPL_STATSILINE = 215,
        //  Reply to STATS
        //  RFC1459:                  I <host> * <host> <port> <class>
        sRPL_STATSKLINE = 216,
        //  Reply to STATS
        //  RFC1459:                  K <host> * <username> <port> <class>
        //sRPL_STATSQLINE = 217 '(CONFLICTING)
        //  RFC1459
        //sRPL_STATSPLINE = 217 '(CONFLICTING)
        //  IRCU
        sRPL_STATSYLINE = 218,
        //  End of RPL_STATS* list.
        //  RFC1459:                  <query> :<info>
        sRPL_ENDOFSTATS = 219,
        //  End of RPL_STATS* list.
        //  RFC1459:                  <query> :<info>
        //sRPL_STATSPLINE = 220 '(CONFLICTING)
        //  HYBRID 
        //sRPL_STATSBLINE = 220 '(CONFLICTING)
        //  BAHAMUT, UNREAL
        sRPL_UMODEIS = 221,
        //  Information about a user's own modes. Some daemons have extended the mode command and certain modes take parameters (like channel modes).
        //  RFC1459:                  <user_modes> [<user_mode_params>]
        //sRPL_MODLIST = 222 (CONFLICTING)
        //sRPL_SQLINE_NICK = 222 '(CONFLICTING)
        //  UNREAL
        //sRPL_STATSBLINE = 222 '(CONFLICTING)
        //  BAHAMUT
        //sRPL_STATSELINE = 223 '(CONFLICTING)
        //  BAHAMUT 
        //sRPL_STATSGLINE = 223 '(CONFLICTING)
        //  UNREAL
        //sRPL_STATSFLINE = 224 '(CONFLICTING)
        //  HYBRID, BAHAMUT
        //sRPL_STATSTLINE = 224 '(CONFLICTING)
        //  UNREAL 
        //sRPL_STATSDLINE = 225 '(CONFLICTING)
        //  HYBRID 
        //sRPL_STATSZLINE = 225 '(CONFLICTING)
        //  BAHAMUT 
        //sRPL_STATSELINE = 225 '(CONFLICTING)
        //  UNREAL 
        //sRPL_STATSCOUNT = 226 '(CONFLICTING)
        //  BAHAMUT 
        //sRPL_STATSNLINE = 226 '(CONFLICTING)
        //  UNREAL
        //sRPL_STATSGLINE = 227 '(CONFLICTING)
        //  BAHAMUT 
        //sRPL_STATSVLINE = 227 '(CONFLICTING)
        //  UNREAL
        //sRPL_STATSQLINE = 228 '(CONFLICTING)
        //  IRCU 
        //sRPL_SERVICEINFO = 231 '(DEPRECIATED)
        //  RFC1459 
        //sRPL_ENDOFSERVICES = 232 '(DEPRECIATED)
        //  RFC1459 
        //sRPL_RULES = 232 '(CONFLICTING)
        //  UNREAL
        //sRPL_SERVICE = 233 '(DEPRECIATED)
        //  RFC1459
        sRPL_SERVLIST = 234,
        //  A service enTry in the service list
        //  RFC2812:                  <name> <server> <mask> <type> <hopcount> <info>
        sRPL_SERVLISTEND = 235,
        //  Termination of an RPL_SERVLIST list
        //  RFC2812:                  <mask> <type> :<info>
        //sRPL_STATSVERBOSE = 236
        //  Verbose server list?
        //  IRCU
        //sRPL_STATSENGINE = 237
        //  Engine name?
        //  IRCU
        //sRPL_STATSFLINE = 238 '(DEPRECIATED)
        //  Feature lines?
        //  IRCU  
        //sRPL_STATSIAUTH = 239
        //  IRCNET
        //sRPL_STATSVLINE = 240 '(CONFLICTING)
        //  RFC2812 
        //sRPL_STATSXLINE = 240 '(CONFLICTING)
        //  AUSTHEX 
        sRPL_STATSLLINE = 241,
        //  Reply to STATS
        //  RFC1459:                  L <hostmask> * <servername> <maxdepth>
        sRPL_STATSUPTIME = 242,
        //  Reply to STATS
        //  RFC1459:                  :Server Up <days> days <hours>:<minutes>:<seconds>
        sRPL_STATSOLINE = 243,
        //  Reply to STATS. The info field is an extension found in some IRC daemons, which returns info such as an e-mail address or the name/job of an operator
        //  RFC1459:                  O <hostmask> * <nick> [:<info>]
        sRPL_STATSHLINE = 244,
        //  Reply to STATS
        //  RFC1459:                  H <hostmask> * <servername>
        //sRPL_STATSSLINE = 245
        //  BAHAMUT, IRCNET, HYBRID
        //sRPL_STATSPING = 246 '(CONFLICTING)
        //  RFC2812 
        //sRPL_STATSULINE = 246 '(CONFLICTING)
        //  HYBRID 
        //sRPL_STATSBLINE = 247 '(CONFLICTING)
        //  RFC2812 
        //sRPL_STATSXLINE = 247 '(CONFLICTING)
        //  HYBRID, PTlink, UNREAL 
        //sRPL_STATSGLINE = 247 '(CONFLICTING)
        //  IRCU 
        //sRPL_STATSULINE = 248 '(CONFLICTING)
        //  IRCU
        //sRPL_STATSDEFINE = 248 '(CONFLICTING)
        //  IRCNET 
        //sRPL_STATSULINE = 249 (CONFLICTING)
        //  Extension to RFC1459?
        //sRPL_STATSDEBUG = 249 (CONFLICTING)
        //sRPL_STATSDLINE = 250 '(CONFLICTING)
        //  RFC2812 
        //sRPL_STATSCONN = 250 '(CONFLICTING)
        //  IRCU, UNREAL 
        sRPL_STATSCONN = 250,
        //  250 :Highest connection count: <total> (<num> clients)
        //  ircu, Unreal
        sRPL_LUSERCLIENT = 251,
        //  Reply to LUSERS command, other versions exist (eg. RFC2812); Text may vary.
        //  RFC1459:                  :There are <int> users and <int> invisible on <int> servers
        sRPL_LUSEROP = 252,
        //  Reply to LUSERS command - Number of IRC operators online
        //  RFC1459:                  <int> :<info>
        sRPL_LUSERUNKNOWN = 253,
        //  Reply to LUSERS command - Number of unknown/unregistered connections
        //  RFC1459:                  <int> :<info>
        sRPL_LUSERCHANNELS = 254,
        //  Reply to LUSERS command - Number of channels formed
        //  RFC1459:                  <int> :<info>
        sRPL_LUSERME = 255,
        //  Reply to LUSERS command - Information about local connections; Text may vary.
        //  RFC1459:                  :I have <int> clients and <int> servers
        sRPL_ADMINME = 256,
        //  Start of an RPL_ADMIN* reply. In practise, the server parameter is often never given, and instead the info field contains the text 'Administrative info about <server>'. Newer daemons seem to follow the RFC and output the server's hostname in the 'server' parameter, but also output the server name in the text as per traditional daemons.
        //  RFC1459:                  <server> :<info>
        sRPL_ADMINLOC1 = 257,
        //  Reply to ADMIN command (Location, first line)
        //  RFC1459:                  :<admin_location>
        sRPL_ADMINLOC2 = 258,
        //  Reply to ADMIN command (Location, second line)
        //  RFC1459:                  :<admin_location>
        sRPL_ADMINEMAIL = 259,
        //  When replying to an ADMIN message, a server is expected to use replies RPL_ADMINME through to RPL_ADMINEMAIL and provide a text message with each. For RPL_ADMINLOC1 a description of what city, state and counTry the server is in is expected, followed by details of the institution (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is REQUIRED) in RPL_ADMINEMAIL.
        //  RFC2812:                  :<admin info>
        sRPL_TRACELOG = 261,
        //  RFC1459:                  File <logfile> <debug_level>
        sRPL_TRACEEND = 262,
        //  Used to terminate a list of RPL_TRACE* replies
        //  RFC2812:                  <server_name> <version>[.<debug_level>] :<info>
        sRPL_TRYAGAIN = 263,
        //  When a server drops a command without processing it, it MUST use this reply. Also known as RPL_LOAD_THROTTLED and RPL_LOAD2HI, I'm presuming they do the same thing.
        //  RFC2812:                  <command> :<info>
        sRPL_LOCALUSERS = 265,
        //  UNREAL, BAHAMUT, HYBRID:  :%s 265 %s :Current local users: %d Max: %d
        sRPL_GLOBALUSERS = 266,
        //  BAHAMUT, HYBRID, UNREAL:  :%s 266 %s :Current global users: %d Max: %d
        //sRPL_PRIVS = 270 
        //  IRCU:                     %s :
        //sRPL_SILELIST = 271
        //  BAHAMUT/UNREAL:           :%s 271 %s %s %s
        //  IRCU:                     %s %s
        //sRPL_ENDOFSILELIST = 272
        //  BAHAMUT:                  :%s 272 %s :End of /SILENCE list.
        //  IRCU:                     %s :End of Silence List
        //  UNREAL:                   :%s 272 %s :End of Silence List
        //sRPL_STATSDLINE = 275
        //  IRCU:                     %c %s %s
        //  UNREAL:                   :%s 275 %s %c %s %s
        //sRPL_GLIST = 280
        //  IRCU:                     %s%s%s %Tu %s %c :%s
        //sRPL_ENDOFGLIST = 281
        //  IRCU:                     :End of G-line List
        //sRPL_JUPELIST = 282
        //  IRCU:                     %s %Tu %s %c :%s
        //sRPL_ENDOFJUPELIST = 283
        //  IRCU:                     :End of Jupe List
        //sRPL_FEATURE = 284
        //  IRCU
        sRPL_HELP = 292,
        //SAW ON NEWNET
        //  Reply to /help. Returns a list of IRC commands
        //  UNKNOWN:                  :irc.internetrelaychat.org 292 guideX : Server Commands Help.
        //sRPL_HELPFWD = 294
        //  UNREAL:                   :%s 294 %s :Your help-request has been forwarded to Help Operators
        //sRPL_HELPIGN = 295
        //  UNREAL:                   :%s 295 %s :Your address has been ignored from forwarding
        sRPL_NONE = 300,
        //  Dummy reply, supposedly only used for debugging/testing new features, however has appeared in production daemons.
        //  'RFC1459, HYBRID, IRC2, IRCU
        sRPL_AWAY = 301,
        //  These replies are used with the AWAY command (if allowed). RPL_AWAY is sent to any client sending a PRIVMSG to a client which is away. RPL_AWAY is only sent by the server to which the client is connected.
        //  Used in reply to a command directed at a user who is marked as away
        //  RFC1459, RFC2812:         <nick> :<message>
        sRPL_USERHOST = 302,
        //  Reply used by USERHOST
        //  RFC1459:                  :*1<reply> *( ' ' <reply> )
        sRPL_ISON = 303,
        //  Reply to the ISON command
        //  RFC1459:                  :*1<nick> *( ' ' <nick> )
        sRPL_UNAWAY = 305,
        //  Reply from AWAY when no longer marked as away
        //  RFC1459:                  :<info>
        sRPL_NOWAWAY = 306,
        //  Reply from AWAY when marked away
        //  RFC1459:                  :<info>
        //sRPL_WHOISREGNICK = 307
        //  BAHAMUT, UNREAL:          :%s 307 %s %s :is a registered nick
        //sRPL_WHOISADMIN = 308 '(CONFLICTING)
        //  BAHAMUT:                  :%s 308 %s %s :is an IRC Server Administrator
        //sRPL_RULESSTART = 308 '(CONFLICTING)
        //  UNREAL:                   :%s 308 %s :- %s Server Rules -
        //sRPL_WHOISSADMIN = 309 '(CONFLICTING)
        //  BAHAMUT:                  :%s 309 %s %s :is a Services Administrator
        //sRPL_ENDOFRULES = 309 '(CONFLICTING)
        //  UNREAL:                   :%s 309 %s :End of RULES command.
        //sRPL_WHOISSVCMSG = 310 '(CONFLICTING)
        //  BAHAMUT:                  :%s 310 %s %s
        //sRPL_WHOISHELPOP = 310 '(CONFLICTING)
        //  UNREAL:                   :%s 310 %s %s :is available for help.
        sRPL_WHOISUSER = 311,
        //  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message. The * in RPL_WHOISUSER is there as the literal character and not as a wild card.
        //  Reply to WHOIS - Information about the user
        //  RFC1459, RFC2812:         <nick> <user> <host> * :<real_name>
        sRPL_WHOISSERVER = 312,
        //  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        //  Reply to WHOIS - What server they're on
        //  'RFC1459, RFC2812:        <nick> <server> :<server_info>
        sRPL_WHOISOPERATOR = 313,
        //  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        //  Reply to WHOIS - User has IRC Operator privileges
        //  RFC1459, RFC2812:        <nick> :<privileges>
        sRPL_WHOWASUSER = 314,
        //  When replying to a WHOWAS message, a server MUST use the replies RPL_WHOWASUSER, RPL_WHOISSERVER or ERR_WASNOSUCHNICK for each nickname in the presented list. At the end of all reply batches, there MUST be RPL_ENDOFWHOWAS (even if there was only one reply and it was an error).
        //  Reply to WHOWAS - Information about the user
        //  RFC1459, RFC2812:         <nick> <user> <host> * :<real_name>
        sRPL_ENDOFWHO = 315,
        //  The RPL_WHOREPLY and RPL_ENDOFWHO pair are used to answer a WHO message. The RPL_WHOREPLY is only sent if there is an appropriate match to the WHO query. If there is a list of parameters supplied with a WHO message, a RPL_ENDOFWHO MUST be sent after processing each list item with <name> being the item
        //  Used to terminate a list of RPL_WHOREPLY replies
        //  RFC1459, RFC2812:         <name> :<info>
        sRPL_WHOISCHANOP = 316,
        //(RESERVED)
        //  RFC1459, RFC2812 
        sRPL_WHOISIDLE = 317,
        //  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        //  Reply to WHOIS - Idle information
        //  RFC1459, RFC2812:         <nick> <seconds> :seconds idle
        //  BAHAMUT:                  :%s 317 %s %s %ld %ld :seconds idle, signon time
        //  UNREAL:                   :%s 317 %s %s %ld %ld :seconds idle, signon time
        //  HYBRID:                   :%s 317 %s %s %d %d :seconds idle, signon time
        //  IRC2:                     %s %ld :seconds idle
        //  IRCU:                     %s %ld %ld :seconds idle, signon time  
        sRPL_ENDOFWHOIS = 318,
        //  Reply to WHOIS - End of list 
        //  RFC1459, RFC2812:         <nick> :<info>
        //  BAHAMUT/HYBRID/UNREAL:    :%s 318 %s %s :End of /WHOIS list.
        //  IRC2:                     %s :End of WHOIS list.
        //  IRCU:                     %s :End of /WHOIS list.
        sRPL_WHOISCHANNELS = 319,
        //  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message. For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The @ and + characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.
        //  Reply to WHOIS - Channel list for user
        //  RFC1459:                  <nick> :*( ( '@' / '+' ) <channel> ' ' )
        //  RFC2812:                  <nick> :*( ( @|+ ) <channel> <space> )
        //  BAHAMUT, HYBRID, UNREAL:  :%s 319 %s %s :%s
        //  IRC2, IRCU:               %s :%s
        //sRPL_WHOISVIRT = 319 (CONFLICTING)
        //  AUSTHEX
        //sRPL_WHOIS_HIDDEN = 320 '(CONFLICTING)
        //  Anothernet 
        //sRPL_WHOISSPECIAL = 320 '(CONFLICTING)
        //  UNREAL                    :%s 320 %s %s :%s
        sRPL_LISTSTART = 321,
        //  Obsolete. Not used. Channel list - Header
        //  RFC1459/IRC2/IRCU:        Channel :Users Name
        //  BAHAMUT/HYBRID/UNREAL:    :%s 321 %s Channel :Users Name
        //sRPL_LIST = 322 '(NO TEXT STRING NESCISARY)
        //  Channel list - A channel
        //  RFC1459:                  <channel> <#_visible> :<topic>
        sRPL_LISTEND = 323,
        //  Channel list - End of list
        //  RFC1459:                  :<info>
        sRPL_CHANNELMODEIS = 324,
        //  RFC1459:                  <channel> <mode> <mode_params>
        //sRPL_UNIQOPIS = 325 '(CONFLICTING)
        //  RFC8212:                  <channel> <nickname>
        //sRPL_CHANNELPASSIS = 325 '(CONFLICTING)
        //sRPL_NOCHANPASS = 326
        //sRPL_CHPASSUNKNOWN = 327
        sRPL_CHANNEL_URL = 328,
        //BAHAMUT, AUSTHEX
        //  This is sent to you by ChanServ when you join a registered channel.
        //  HYPERION:                 :<server> 328 <nickname> <channel> :<url>
        //sRPL_CREATIONTIME = 329 
        //  BAHAMUT, HYBRID, UNREAL   :%s 329 %s %s %lu
        //  IRCU:                     %s %Tu
        //sRPL_WHOWAS_TIME = 330 '(CONFLICTING)
        sRPL_WHOISACCOUNT = 330,
        //(CONFLICTING)
        //  IRCU:                 <nick> <authname> :<info>
        sRPL_NOTOPIC = 331,
        //RFC1459, RFC2812
        //  When sending a TOPIC message to determine the channel topic, one of two replies is sent. If the topic is set, RPL_TOPIC is sent back else RPL_NOTOPIC.
        //  <channel> :<info>
        sRPL_TOPIC = 332,
        //RFC1459, RFC2812
        //  When sending a TOPIC message to determine the channel topic, one of two replies is sent. If the topic is set, RPL_TOPIC is sent back else RPL_NOTOPIC.
        //  Response to TOPIC with the set topic
        //  <channel> :<topic>
        //sRPL_TOPIC = 332 'BAHAMUT, HYBRID, IRC2, IRCU, UNREAL (CONFLICTING)
        //  BAHAMUT, HYBRID, UNREAL:   :%s 332 %s %s :%s
        //  IRC2, IRCU:               %s :%s
        sRPL_TOPICWHOTIME = 333,
        //IRCU
        //  This is returned for a TOPIC request or when you JOIN, if the channel has a topic.
        //  IRCU:                     :<server> 333 <channel> <nickname> <time>
        //sRPL_LISTUSAGE = 334 'IRCU (CONFLICTING)
        //sRPL_COMMANDSYNTAX = 334 'BAHAMUT (CONFLICTING)
        //sRPL_LISTSYNTAX = 334 'UNREAL (CONFLICTING)
        //sRPL_WHOISBOT = 335 'UNREAL
        //sRPL_CHANPASSOK = 338 (CONFLICTING)
        sRPL_WHOISACTUALLY = 338,
        //IRCU, BAHAMUT (CONFLICTING)
        //  bahumut:                  :%s 338 %s :%s is actually %s@%s [%s]
        //  IRCU:                     %s %s@%s %s :Actual user@host, Actual IP
        //sRPL_BADCHANPASS = 339
        //sRPL_USERIP = 340 
        //  IRCU
        sRPL_INVITING = 341,
        //  Returned by the server to indicate that the attempted INVITE message was successful and is being passed onto the end client. Note that RFC1459 documents the parameters in the reverse order. The format given here is the format used on production servers, and should be considered the standard reply above that given by RFC1459.
        //  RFC1459:                  <nick> <channel>
        sRPL_SUMMONING = 342,
        //  Returned by a server answering a SUMMON message to indicate that it is summoning that user
        //  RFC1459:                  <user> :<info>
        //sRPL_INVITED = 345
        //  Sent to users on a channel when an INVITE command has been issued
        //  GameSurge:                <channel> <user being invited> <user issuing invite> :<user being invited> has been invited by <user issuing invite>
        sRPL_INVITELIST = 346,
        //  An invite mask for the invite mask list
        //  RFC2812:                  <channel> <invitemask>
        sRPL_ENDOFINVITELIST = 347,
        //  Termination of an RPL_INVITELIST list
        //  RFC2812:                  <channel> :<info>
        sRPL_EXCEPTLIST = 348,
        //  An exception mask for the exception mask list. Also known as RPL_EXLIST (UNREAL, Ultimate)
        //  RFC2812:                  <channel> <exceptionmask>
        sRPL_ENDOFEXCEPTLIST = 349,
        //  Termination of an RPL_EXCEPTLIST list. Also known as RPL_ENDOFEXLIST (UNREAL, Ultimate)
        //  RFC2812:                  <channel> :<info>
        sRPL_VERSION = 351,
        //  Reply by the server showing its version details, however this format is not often adhered to
        //  RFC1459:                  <version>[.<debuglevel>] <server> :<comments>
        sRPL_WHOREPLY = 352,
        //  Reply to vanilla WHO (See RFC). This format can be very different if the 'WHOX' version of the command is used (see IRCU).
        //  RFC1459:                  <channel> <user> <host> <server> <nick> <H|G>[*][@|+] :<hopcount> <real_name>
        sRPL_NAMREPLY = 353,
        //  Reply to NAMES
        //  RFC1459:                  ( '=' / '*' / '@' ) <channel> ' ' : [ '@' / '+' ] <nick> *( ' ' [ '@' / '+' ] <nick> )
        //  EXAMPLE:                  :irc.ircsoulz.org 353 guide_X = #test :@guide_X 
        //sRPL_WHOSPCRPL = 354
        //  Reply to WHO, however it is a 'special' reply because it is returned using a non-standard (non-RFC1459) format. The format is dictated by the command given by the user, and can vary widely. When this is used, the WHO command was invoked in its 'extended' form, as announced by the 'WHOX' ISUPPORT tag.
        //  IRCU
        //sRPL_NAMREPLY_ = 355
        //  Reply to the "NAMES -d" command - used to show invisible users (when the channel is set +D, QuakeNet relative). The proper define name for this numeric is unknown at this time Also see #353.
        //  QuakeNet
        //sRPL_MAP = 357 'AUSTHEX (DEPRECIATED)
        //sRPL_MAPMORE = 358 'AUSTHEX (DEPRECIATED)
        //sRPL_MAPEND = 359 'AUSTHEX (DEPRECIATED)
        //sRPL_KILLDONE = 361 'RFC1459 (DEPRECIATED)
        //sRPL_CLOSING = 362 'RFC1459 (DEPRECIATED)
        //sRPL_CLOSEEND = 363 'RFC1459 (DEPRECIATED)
        sRPL_LINKS = 364,
        //  Reply to the LINKS command
        //  RFC1459:                  <mask> <server> :<hopcount> <server_info>
        sRPL_ENDOFLINKS = 365,
        //  Termination of an RPL_LINKS list
        //  RFC1459:                  <mask> :<info>
        sRPL_ENDOFNAMES = 366,
        //  Termination of an RPL_NAMREPLY list
        //  RFC1459:                  <channel> :<info>
        //  EXAMPLE:                  :irc.ircsoulz.org 366 guide_X #test :End of /NAMES list.
        sRPL_BANLIST = 367,
        //  A ban-list item (See RFC); <time left> and <reason> are additions used by KineIRCd
        //  RFC1459:                  <channel> <banid> [<time_left> :<reason>]
        sRPL_ENDOFBANLIST = 368,
        //  Termination of an RPL_BANLIST list
        //  RFC1459:                  <channel> :<info>
        sRPL_ENDOFWHOWAS = 369,
        //  Reply to WHOWAS - End of list
        //  RFC1459:                  <nick> :<info>
        sRPL_INFO = 371,
        //  A server responding to an INFO message is required to send all its 'info' in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
        //  RFC2812:                  :<string>
        sRPL_MOTD = 372,
        //  Reply To /MOTD
        //  RFC1459:                  :- <string>
        //sRPL_INFOSTART = 373 '(RESERVED)
        //  RFC2812
        sRPL_ENDOFINFO = 374,
        //  A server responding to an INFO message is required to send all its 'info' in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
        //  RFC2812:                  :End of INFO list
        sRPL_MOTDSTART = 375,
        //  When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies. These MUST be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
        //  RFC2812:                  :- <server> Message of the day -
        sRPL_ENDOFMOTD = 376,
        //  When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies. These MUST be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
        //  RFC2812:                  :End of MOTD command
        //sRPL_SPAM = 377 '(DEPRECIATED)
        //  Used during the connection (after MOTD) to announce the network policy on spam and privacy. Supposedly now obsoleted in favour of using NOTICE.
        //  AUSTHEX:                  :<text>
        //sRPL_KICKEXPIRED = 377 '(CONFLICTING)
        //  AIRCD
        //sRPL_BANEXPIRED = 378
        //  AIRCD
        sRPL_WHOISHOST = 378,
        //  UNREAL
        //sRPL_FORCEMOTD = 378 (CONFLICTING)
        //  Used by AUSTHEX to 'force' the display of the MOTD, however is considered obsolete due to client/script awareness & ability to Also see #372.
        //  AUSTHEX
        //sRPL_KICKLINKED = 379
        //  AIRCD
        sRPL_WHOISMODES = 379,
        //  UNREAL 
        //sRPL_BANLINKED = 380 
        //  AIRCD
        //sRPL_YOURHELPER = 380 
        //  AUSTHEX
        sRPL_YOUREOPER = 381,
        //  RPL_YOUREOPER is sent back to a client which has just successfully issued an OPER message and gained operator status.
        //  RFC2812:                  :You are now an IRC operator
        sRPL_REHASHING = 382,
        //  If the REHASH option is used and an operator sends a REHASH message, an RPL_REHASHING is sent back to the operator.
        //  RFC14:                  <config file> :Rehashing
        sRPL_YOURESERVICE = 383,
        //  Sent upon successful registration of a service
        //  RFC2812:                 :You are service <service_name>
        //sRPL_MYPORTIS = 384 (RESERVED)
        //  RFC1459
        //sRPL_NOTOPERANYMORE = 385
        //  AUSTHEX, HYBRID, UNREAL
        //sRPL_QLIST = 386
        //  UNREAL
        //sRPL_IRCOPS = 386
        //  ULTIMATE
        //sRPL_ENDOFQLIST = 387
        //sRPL_ALIST = 388
        //  UNREAL
        //sRPL_ENDOFALIST = 389
        //  UNREAL
        sRPL_TIME = 391,
        //  Response to the TIME command. The string format may vary greatly. Also see #679.
        //  RFC1459:                  <server> :<time string>
        //  IRCU:                     <server> <timestamp> <offset> :<time string>
        sRPL_USERSSTART = 392,
        //  Start of an RPL_USERS list
        //  RFC1459:                  :UserID Terminal Host
        sRPL_USERS = 393,
        //  Response to the USERS command (See RFC)
        //  RFC1459:                  :<username> <ttyline> <hostname>
        sRPL_ENDOFUSERS = 394,
        //  Termination of an RPL_USERS list
        //  RFC1459:                  :<info>
        sRPL_NOUSERS = 395,
        //  Reply to USERS when nobody is logged in
        //  RFC1459:                  :<info>
        sRPL_HOSTHIDDEN = 396,
        //  UNDERNET
        //  Reply to a user when user mode +x (host masking) was set successfully
        sERR_UNKNOWNERROR = 400,
        //  Sent when an error occured executing a command, but it is not specifically known why the command could not be executed.
        //  UNKNOWN:                  <command> [<?>] :<info>
        sERR_NOSUCHNICK = 401,
        //  Used to indicate the nickname parameter supplied to a command is currently unused
        //  RFC1459:                  <nick> :<reason>
        sERR_NOSUCHSERVER = 402,
        //  Used to indicate the server name given currently doesn't exist
        //  RFC1459:                  <server> :<reason>
        sERR_NOSUCHCHANNEL = 403,
        //  Used to indicate the given channel name is invalid, or does not exist
        //  RFC1459:                  <channel> :<reason>
        sERR_CANNOTSENDTOCHAN = 404,
        //  Sent to a user who does not have the rights to send a message to a channel
        //  RFC1459:                  <channel> :<reason>
        sERR_TOOMANYCHANNELS = 405,
        //  Sent to a user when they have joined the maximum number of allowed channels and they tried to join another channel
        //  RFC1459:                  <channel> :<reason>
        sERR_WASNOSUCHNICK = 406,
        //  Returned by WHOWAS to indicate there was no history information for a given nickname
        //  RFC1459:                  <nick> :<reason>
        sERR_TOOMANYTARGETS = 407,
        //  The given target(s) for a command are ambiguous in that they relate to too many targets
        //  RFC1459:                  <target> :<reason>
        sERR_NOSUCHSERVICE = 408,
        //  Returned to a client which is attempting to send an SQUERY (or other message) to a service which does not exist
        //  RFC1459:                  <service_name> :<reason>
        //sERR_NOCOLORSONCHAN = 408 (DEPRECIATED)
        //  BAHAMUT
        sERR_NOORIGIN = 409,
        //  PING or PONG message missing the originator parameter which is required since these commands must work without valid prefixes
        //  RFC1459:                  :<reason>
        sERR_NORECIPIENT = 411,
        //  Returned when no recipient is given with a command
        //  RFC1459:                  :<reason>
        sERR_NOTEXTTOSEND = 412,
        //  Returned when NOTICE/PRIVMSG is used with no message given
        //  RFC1459:                  :<reason>
        sERR_NOTOPLEVEL = 413,
        //  Used when a message is being sent to a mask without being limited to a top-level domain (i.e. * instead of *.au)
        //  RFC1459:                  <mask> :<reason>
        sERR_WILDTOPLEVEL = 414,
        //  Used when a message is being sent to a mask with a wild-card for a top level domain (i.e. *.*)
        //  RFC1459:                  <mask> :<reason>
        sERR_BADMASK = 415,
        //  Used when a message is being sent to a mask with an invalid syntax
        //  RFC1459:                  <mask> :<reason>
        //sERR_TOOMANYMATCHES = 416 (CONFLICTING)
        //  Returned when too many matches have been found for a command and the output has been truncated. An example would be the WHO command, where by the mask '*' would match everyone on the network! Ouch!
        //  IRCNET:                   <command> [<mask>] :<info>
        //sERR_QUERYTOOLONG = 416 (CONFLICTING)
        //  IRCU:                     Same as ERR_TOOMANYMATCHES
        //sERR_LENGTHTRUNCATED = 419
        //  AIRCD
        sERR_UNKNOWNCOMMAND = 421,
        //  Returned when the given command is unknown to the server (or hidden because of lack of access rights)
        //  RFC1459:                  <command> :<reason>
        sERR_NOMOTD = 422,
        //  Sent when there is no MOTD to send the client
        //  RFC1459:                  :<reason>
        sERR_NOADMININFO = 423,
        //  Returned by a server in response to an ADMIN request when no information is available. RFC1459 mentions this in the list of numerics. While it's not listed as a valid reply in section 4.3.7 ('Admin command'), it's confirmed to exist in the real world.
        //  RFC1459:                  <server> :<reason>
        sERR_FILEERROR = 424,
        //  Generic error message used to report a failed file operation during the processing of a command
        //  RFC1459:                  :<reason>
        //sERR_NOOPERMOTD = 425
        //  UNREAL 
        //sERR_TOOMANYAWAY = 429
        //  BAHAMUT
        //sERR_EVENTNICKCHANGE = 430
        //  Returned by NICK when the user is not allowed to change their nickname due to a channel event (channel mode +E)
        //  AUSTHEX
        sERR_NONICKNAMEGIVEN = 431,
        //  Returned when a nickname parameter expected for a command isn't found
        //  RFC1459:                  :<reason>
        sERR_ERRONEUSNICKNAME = 432,
        //  Returned after receiving a NICK message which contains a nickname which is considered invalid, such as it's reserved ('anonymous') or contains characters considered invalid for nicknames. This numeric is misspelt, but remains with this name for historical reasons :)
        //  RFC1459:                  <nick> :<reason>
        sERR_NICKNAMEINUSE = 433,
        //  Returned by the NICK command when the given nickname is already in use
        //  RFC1459:                  <nick> :<reason>
        //sERR_SERVICENAMEINUSE = 434 (CONFLICTING)
        //  AUSTHEX
        //sERR_NORULES = 434 (CONFLICTING)
        //  UNREAL, Ultimate
        //sERR_SERVICECONFUSED = 435 (CONFLICTING)
        //  UNREAL
        //sERR_BANONCHAN = 435 (CONFLICTING)
        //  BAHAMUT
        sERR_NICKCOLLISION = 436,
        //  Returned by a server to a client when it detects a nickname collision
        //  RFC1459:                  <nick> :<reason>
        sERR_UNAVAILRESOURCE = 437,
        //  Return when the target is unable to be reached temporarily, eg. a delay mechanism in play, or a service being offline
        //  RFC2812:                  <nick/channel/service> :<reason>
        //sERR_BANNICKCHANGE = 437
        //  IRCU
        //sERR_NICKTOOFAST = 438
        //  IRCU
        //sERR_DEAD = 438
        //  IRCNET
        sERR_TARGETTOOFAST = 439,
        //  IRCU:                     Also known as many other things, RPL_INVTOOFAST, RPL_MSGTOOFAST etc
        //sERR_SERVICESDOWN = 440
        //  BAHAMUT, UNREAL
        sERR_USERNOTINCHANNEL = 441,
        //  Returned by the server to indicate that the target user of the command is not on the given channel
        //  RFC1459:                  <nick> <channel> :<reason>
        sERR_NOTONCHANNEL = 442,
        //  Returned by the server whenever a client tries to perform a channel effecting command for which the client is not a member
        //  RFC1459:                  <channel> :<reason>
        sERR_USERONCHANNEL = 443,
        //  Returned when a client tries to invite a user to a channel they're already on
        //  RFC1459:                  <nick> <channel> [:<reason>]
        sERR_NOLOGIN = 444,
        //  Returned by the SUMMON command if a given user was not logged in and could not be summoned
        //  RFC1459:                  <user> :<reason>
        sERR_SUMMONDISABLED = 445,
        //  Returned by SUMMON when it has been disabled or not implemented
        //  RFC1459:                  :<reason>
        sERR_USERSDISABLED = 446,
        //  Returned by USERS when it has been disabled or not implemented
        //  RFC1459:                  :<reason>
        //sERR_NONICKCHANGE = 447
        //  UNREAL
        //sERR_NOTIMPLEMENTED = 449
        //  Returned when a requested feature is not implemented (and cannot be completed)
        //  Undernet:                 Unspecified 
        sERR_NOTREGISTERED = 451,
        //  Returned by the server to indicate that the client must be registered before the server will allow it to be parsed in detail
        //  RFC1459:                  :<reason>
        //sERR_IDCOLLISION = 452
        //sERR_NICKLOST = 453
        //sERR_HOSTILENAME = 455
        //  UNREAL
        //sERR_ACCEPTFULL = 456
        //sERR_ACCEPTEXIST = 457
        //sERR_ACCEPTNOT = 458
        //sERR_NOHIDING = 459
        //  Not allowed to become an invisible operator?
        //  UNREAL 
        //sERR_NOTFORHALFOPS = 460
        //  UNREAL
        sERR_NEEDMOREPARAMS = 461,
        //  Returned by the server by any command which requires more parameters than the number of parameters given
        //  RFC1459:                  <command> :<reason>
        sERR_ALREADYREGISTERED = 462,
        //  Returned by the server to any link which attempts to register again
        //  RFC1459:                  :<reason>
        sERR_NOPERMFORHOST = 463,
        //  Returned to a client which attempts to register with a server which has been configured to refuse connections from the client's host
        //  RFC1459:                  :<reason>
        sERR_PASSWDMISMATCH = 464,
        //  Returned by the PASS command to indicate the given password was required and was either not given or was incorrect
        //  RFC1459:                  :<reason>
        sERR_YOUREBANNEDCREEP = 465,
        //  Returned to a client after an attempt to register on a server configured to ban connections from that client
        //  RFC1459:                  :<reason>
        //sERR_YOUWILLBEBANNED = 466 '(DEPRECIATED)
        //  Sent by a server to a user to inform that access to the server will soon be denied
        //  UNKNOWN
        sERR_KEYSET = 467,
        //  Returned when the channel key for a channel has already been set
        //  RFC1459:                  <channel> :<reason>
        sERR_INVALIDUSERNAME = 468,
        //(CONFLICTING)
        //  IRCU
        //sERR_ONLYSERVERSCANCHANGE = 468 '(CONFLICTING)
        //  BAHAMUT, UNREAL
        //sERR_LINKSET = 469
        //  UNREAL
        sERR_LINKCHANNEL = 470,
        //  This mode allows operators to forward non-excepted users to a secondary channel. Presumably this is intended behavior by the channel operators, although you could attempt to rejoin the primary channel - you would have to contact the channel operators with any channel-specific policy questions.
        //  UNREAL
        //  :holmes.freenode.net 470 guideX #c ##c-unregistered :Forwarding to another channel
        //sERR_KICKEDFROMCHAN = 470
        //  AIRCD
        sERR_CHANNELISFULL = 471,
        //  Returned when attempting to join a channel which is set +l and is already full
        //  RFC1459:                  <channel> :<reason>
        sERR_UNKNOWNMODE = 472,
        //  Returned when a given mode is unknown
        //  RFC1459:                  <char> :<reason>
        sERR_INVITEONLYCHAN = 473,
        //  Returned when attempting to join a channel which is invite only without an invitation
        //  RFC1459:                  <channel> :<reason>
        //  BAHAMUT/HYBRID/UNREAL:    :%s 473 %s %s :Cannot join channel (+i)
        //  IRCU/IRC2:                %s :Cannot join channel (+i)
        sERR_BANNEDFROMCHAN = 474,
        //  Returned when attempting to join a channel a user is banned from
        //  RFC1459:                  <channel> :<reason>
        //  BAHAMUT/HYBRID/UNREAL:    :%s 474 %s %s :Cannot join channel (+b)
        //  IRC2/IRCU:                %s :Cannot join channel (+b)
        sERR_BADCHANNELKEY = 475,
        //  Returned when attempting to join a key-locked channel either without a key or with the wrong key
        //  RFC1459:                  <channel> :<reason>
        sERR_BADCHANMASK = 476,
        //  The given channel mask was invalid
        //  RFC2812:                  <channel> :<reason>
        sERR_NOCHANMODES = 477,
        //  Returned when attempting to set a mode on a channel which does not support channel modes, or channel mode changes. Also known as ERR_MODELESS
        //  RFC2812:                  <channel> :<reason>
        //sERR_NEEDREGGEDNICK = 477 '(CONFLICTING)
        //  BAHAMUT, IRCU, UNREAL
        //:niven.freenode.net 477 nirc #testerama :[freenode-info] if you need to send private messages, please register: http://freenode.net/faq.shtml#privmsg
        sERR_BANLISTFULL = 478,
        //  Returned when a channel access list (i.e. ban list etc) is full and cannot be added to
        //  RFC2812:                  <channel> <char> :<reason>
        sERR_BADCHANNAME = 479,
        //  HYBRID 
        //  EXAMPLE:                  :card.freenode.net 479 nirc m JOIN :#ubuntu :Illegal channel name
        //sERR_LINKFAIL = 479
        //  UNREAL
        //sERR_NOULINE = 480 '(CONFLICTING)
        //  AUSTHEX
        //sERR_CANNOTKNOCK = 480 '(CONFLICTING)
        //  UNREAL
        sERR_NOPRIVILEGES = 481,
        //  Returned by any command requiring special privileges (eg. IRC operator) to indicate the operation was unsuccessful
        //  RFC1459:                  :<reason>
        sERR_CHANOPRIVSNEEDED = 482,
        //  Returned by any command requiring special channel privileges (eg. channel operator) to indicate the operation was unsuccessful
        //  RFC1459:                  <channel> :<reason>
        sERR_CANTKILLSERVER = 483,
        //  Returned by KILL to anyone who tries to kill a server
        //  RFC1459:                  :<reason>
        sERR_RESTRICTED = 484,
        //  Sent by the server to a user upon connection to indicate the restricted nature of the connection (i.e. usermode +r)
        //  RFC2812:                  :<reason>
        //sERR_ISCHANSERVICE = 484
        //  Undernet 
        //sERR_DESYNC = 484
        //  BAHAMUT, HYBRID, PTlink
        //sERR_ATTACKDENY = 484
        //  UNREAL
        sERR_UNIQOPRIVSNEEDED = 485,
        //  Any mode requiring 'channel creator' privileges returns this error if the client is attempting to use it while not a channel creator on the given channel
        //  RFC2812:                  :<reason>
        //sERR_KILLDENY = 485 (CONFLICTING)
        //  UNREAL
        //sERR_CANTKICKADMIN = 485 (CONFLICTING)
        //  PTlink
        //sERR_ISREALSERVICE = 485 (CONFLICTING)
        //  QuakeNet
        //sERR_NONONREG = 486 (CONFLICTING)
        //sERR_HTMDISABLED = 486 (CONFLICTING)
        //  UNREAL 
        //sERR_ACCOUNTONLY = 486 (CONFLICTING)
        //  QuakeNet
        //sERR_CHANTOORECENT = 487 (CONFLICTING)
        //  IRCNET
        //sERR_MSGSERVICES = 487 (CONFLICTING)
        //  BAHAMUT
        //sERR_TSLESSCHAN = 488 
        //  IRCNET
        //sERR_VOICENEEDED = 489
        //  Undernet
        //sERR_SECUREONLYCHAN = 489
        //  UNREAL
        sERR_NOOPERHOST = 491,
        //  RFC1459:                  :<reason>
        //sERR_NOSERVICEHOST = 492 (DEPRECIATED)
        //  RFC1459
        //sERR_NOFEATURE = 493
        //  IRCU
        //sERR_BADFEATURE = 494
        //  IRCU
        //sERR_BADLOGTYPE = 495
        //  IRCU
        //sERR_BADLOGSYS = 496
        //  IRCU
        //sERR_BADLOGVALUE = 497
        //  IRCU
        //sERR_ISOPERLCHAN = 498
        //  IRCU
        //sERR_CHANOWNPRIVNEEDED = 499
        //  Works just like ERR_CHANOPRIVSNEEDED except it indicates that owner status (+q) is needed. Also see #482.
        //  UNREAL
        sERR_UMODEUNKNOWNFLAG = 501,
        //  Returned by the server to indicate that a MODE message was sent with a nickname parameter and that the mode flag sent was not recognised
        //  RFC1459:                  :<reason>
        sERR_USERSDONTMATCH = 502,
        //  Error sent to any user Trying to view or change the user mode for a user other than themselves
        //  RFC1459:                  :<reason>
        //sERR_GHOSTEDCLIENT = 503
        //  HYBRID
        //sERR_VWORLDWARN = 503
        //  Warning about Virtual-World being turned off. Obsoleted in favour for RPL_MODECHANGEWARN Also see #662.
        //  :<warning_text>
        //sERR_USERNOTONSERV = 504
        //sERR_SILELISTFULL = 511
        //  IRCU
        //sERR_TOOMANYWATCH = 512
        //  Also known as ERR_NOTIFYFULL (AIRCD), I presume they are the same
        //  BAHAMUT 
        //sERR_BADPING = 513
        //  Also known as ERR_NEEDPONG (UNREAL/Ultimate) for use during registration, however it's not used in UNREAL (and might not be used in Ultimate either).
        //sERR_INVALID_ERROR = 514 '(CONFLICTING)
        //  IRCU
        //sERR_TOOMANYDCC = 513 '(CONFLICTING)
        //  BAHAMUT
        //sERR_BADEXPIRE = 515
        //  IRCU
        //sERR_DONTCHEAT = 516
        //  IRCU
        //sERR_DISABLED = 517
        //  IRCU
        //sERR_NOINVITE = 518 '(CONFLICTING)
        //  UNREAL
        //sERR_LONGMASK = 518 '(CONFLICTING)
        //  IRCU
        //sERR_ADMONLY = 519 '(CONFLICTING)
        //  UNREAL
        //sERR_TOOMANYUSERS = 519 '(CONFLICTING)
        //  IRCU
        //sERR_OPERONLY = 520 '(CONFLICTING)
        //  UNREAL
        //sERR_MASKTOOWIDE = 520 '(CONFLICTING)
        //  IRCU
        //sERR_WHOTRUNC = 520 '(CONFLICTING)
        //  This is considered obsolete in favour of ERR_TOOMANYMATCHES, and should no longer be used. Also see #416.
        //  AUSTHEX
        //sERR_LISTSYNTAX = 521 '(DEPRECIATED)
        //  BAHAMUT
        //sERR_WHOSYNTAX = 522
        //  BAHAMUT
        //sERR_WHOLIMEXCEED = 523
        //  BAHAMUT
        //sERR_QUARANTINED = 524 '(CONFLICTING)
        //  IRCU 
        //sERR_OPERSPVERIFY = 524 '(CONFLICTING)
        //  UNREAL
        //sERR_REMOTEPFX = 525 '(PROPOSED)
        //  CAPAB USERCMDPFX:         <nickname> :<reason>
        //sERR_PFXUNROUTABLE = 526 '(PROPOSED)
        //  CAPAB USERCMDPFX:         <nickname> :<reason>
        //sERR_BADHOSTMASK = 550
        //  QuakeNet
        //sERR_HOSTUNAVAIL = 551
        //  QuakeNet
        //sERR_USINGSLINE = 552
        //  QuakeNet
        //sERR_STATSSLINE = 553 '(DEPRECIATED)
        //  QuakeNet
        //sRPL_LOGON = 600
        //  BAHAMUT, UNREAL:          :%s 600 %s %s %s %s %d :logged online
        //sRPL_LOGOFF = 601
        //  BAHAMUT, UNREAL:          :%s 600 %s %s %s %s %d :logged online
        //sRPL_WATCHOFF = 602
        //  BAHAMUT, UNREAL:          :%s 602 %s %s %s %s %d :stopped watching
        //sRPL_WATCHSTAT = 603
        //  BAHAMUT, UNREAL:          :%s 603 %s :You have %d and are on %d WATCH entries
        sRPL_NOWON = 604,
        //  BAHAMUT, UNREAL:          :%s 604 %s %s %s %s %d :is online
        sRPL_NOWOFF = 605,
        //  BAHAMUT, UNREAL:          :%s 605 %s %s %s %s %d :is offline
        sRPL_WATCHLIST = 606,
        //  BAHAMUT, UNREAL:          :%s 606 %s :%s
        sRPL_ENDOFWATCHLIST = 607,
        //  BAHAMUT, UNREAL:          :%s 607 %s :End of WATCH %c
        //sRPL_WATCHCLEAR = 608
        //  Ultimate
        sRPL_MAPMORE = 610,
        //(CONFLICTING)
        //  UNREAL:                   :%s 610 %s :%s%-*s --> *more*
        //sRPL_ISOPER = 610 '(CONFLICTING)
        //  Ultimate
        //sRPL_ISLOCOP = 611
        //  Ultimate 
        //sRPL_ISNOTOPER = 612
        //  Ultimate
        //sRPL_ENDOFISOPER = 613
        //  Ultimate
        //sRPL_MAPMORE = 615 '(DEPRECIATED)
        //  PTlink
        sRPL_WHOISMODES2 = 615,
        //  Ultimate
        sRPL_WHOISHOST2 = 616,
        //  Ultimate
        //sRPL_DCCSTATUS = 617
        //  BAHAMUT:                  :%s 617 %s :%s has been %s your DCC allow list
        //sRPL_DCCLIST = 618
        //  BAHAMUT:                  :%s 618 %s :%s
        //sRPL_ENDOFDCCLIST = 619 '(CONFLICTING)
        //  BAHAMUT:                  :%s 619 %s :End of DCCALLOW %s
        //sRPL_DCCINFO = 620 '(CONFLICTING)
        //  BAHAMUT:                  :%s 620 %s :%s
        //sRPL_RULESSTART = 620 '(CONFLICTING)
        //  ULTIMATE
        //sRPL_RULES = 621 '(DEPRECIATED)
        //  ULTIMATE
        //sRPL_ENDOFRULES = 622 '(DEPRECIATED)
        //  ULTIMATE
        //sRPL_MAPMORE = 623 '(DEPRECIATED)
        //  ULTIMATE
        //sRPL_OMOTDSTART = 624
        //  ULTIMATE
        //sRPL_OMOTD = 625
        //  ULTIMATE
        //sRPL_ENDOFO = 626
        //  ULTIMATE
        //sRPL_SETTINGS = 630
        //  ULTIMATE
        //sRPL_ENDOFSETTINGS = 631
        //  ULTIMATE
        //sRPL_DUMPING '(DEPRECIATED)
        //  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        //sRPL_DUMPRPL = 641 '(DEPRECIATED)
        //  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        //sRPL_EODUMP = 642 '(DEPRECIATED)
        //  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        //sRPL_TRACEROUTE_HOP = 660
        //  Returned from the TRACEROUTE IRC-Op command when tracerouting a host
        //  KINEIRCD:                 <target> <hop#> [<address> [<hostname> | '*'] <usec_ping>]
        //sRPL_TRACEROUTE_START = 661
        //  Start of an RPL_TRACEROUTE_HOP list
        //  <target> <target_FQDN> <target_address> <max_hops>
        //sRPL_MODECHANGEWARN = 662
        //  Plain text warning to the user about turning on or off a user mode. If no '+' or '-' prefix is used for the mode char, '+' is presumed.
        //                                   ['+' | '-']<mode_char> :<warning>
        //sRPL_CHANREDIR = 663
        //  Used to notify the client upon JOIN that they are joining a different channel than expected because the IRC Daemon has been set up to map the channel they attempted to join to the channel they eventually will join.
        //                                   <old_chan> <new_chan> :<info>
        //sRPL_SERVMODEIS = 664
        //  Reply to MODE <servername>. KineIRCd supports server modes to simplify configuration of servers; Similar to RPL_CHANNELMODEIS
        //                                   <server> <modes> <parameters>..
        //sRPL_OTHERUMODEIS = 665
        //  Reply to MODE <nickname> to return the user-modes of another user to help troubleshoot connections, etc. Similar to RPL_UMODEIS, however including the target
        //                                   <nickname> <modes>
        //sRPL_ENDOF_GENERIC = 666
        //  Generic response for new lists to save numerics.
        //                                   <command> [<parameter> ...] :<info>
        //sRPL_WHOWASDETAILS = 670
        //  Returned by WHOWAS to return extended information (if available). The type field is a number indication what kind of information.
        //  KineIRCd:                 <nick> <type> :<information>
        //sRPL_WHOISSECURE = 671
        //  Reply to WHOIS command - Returned if the target is connected securely, eg. type may be TLSv1, or SSLv2 etc. If the type is unknown, a '*' may be used.
        //  KineIRCd:                 <nick> <type> [:<info>]
        //sRPL_UNKNOWNMODES = 672
        //  Returns a full list of modes that are unknown when a client issues a MODE command (rather than one numeric per mode)
        //  Ithildin:                     <modes> :<info>
        //sRPL_CANNOTSETMODES = 673
        //  Returns a full list of modes that cannot be set when a client issues a MODE command
        //  Ithildin:                     <modes> :<info>
        //sRPL_LUSERSTAFF = 678
        //  Reply to LUSERS command - Number of network staff (or 'helpers') online (differs from Local/Global operators). Similar format to RPL_LUSEROP
        //  KINEIRCD:                 <staff_online_count> :<info>
        //sRPL_TIMEONSERVERIS = 679
        //  Optionally sent upon connection, and/or sent as a reply to the TIME command. This returns the time on the server in a uniform manner. The seconds (and optionally nanoseconds) is the time since the UNIX Epoch, and is used since many existing timestamps in the IRC-2 protocol are done this way (i.e. ban lists). The timezone is hours and minutes each of Greenwich ('[+/-]HHMM'). Since all timestamps sent from the server are in a similar format, this numeric is designed to give clients the ability to provide accurate timestamps to their users.
        //  KINEIRCD:                 <seconds> [<nanoseconds> | '0'] <timezone> <flags> :<info>
        //sRPL_NETWORKS = 682
        //  A reply to the NETWORKS command when requesting a list of known networks (within the IIRC domain).
        //  KINEIRCD:                 <name> <through_name> <hops> :<info>
        //sRPL_YOURLANGUAGEIS = 687
        //  Reply to the LANGUAGE command, informing the client of the language(s) it has set
        //  KINEIRCD:                 <code(s)> :<info>
        //sRPL_LANGUAGE = 688
        //  A language reply to LANGUAGE when requesting a list of known languages
        //  KINEIRCD:                 <code> <revision> <maintainer> <flags> * :<info>
        //sRPL_WHOISSTAFF = 689
        //  The user is a staff member. The information may explain the user's job role, or simply state that they are a part of the network staff. Staff members are not IRC operators, but rather people who have special access in association with network services. KineIRCd uses this numeric instead of the existing numerics due to the overwhelming number of conflicts.
        //  KINEIRCD:                 :<info>
        //sRPL_WHOISLANGUAGE = 690
        //  Reply to WHOIS command - A list of languages someone can speak. The language codes are comma delimitered.
        //  KINEIRCD:                 <nick> <language codes>
        //sRPL_MODLIST = 702
        //  Output from the MODLIST command
        //  RATBOX:                   <?> 0x<?> <?> <?>
        //sRPL_ENDOFMODLIST = 703
        //  Terminates MODLIST output
        //  RATBOX:                   RATBOX:                   :<text>
        //sRPL_HELPSTART = 704
        //  Start of HELP command output
        //  RATBOX:                   <command> :<text>
        //sRPL_HELPTXT = 705
        //  Output from HELP command
        //  RATBOX:                   <command> :<text>
        //sRPL_ENDOFHELP = 706
        //  End of HELP command output
        //  RATBOX:                   <command> :<text>
        //sRPL_ETRACEFULL = 708
        //  Output from 'extended' trace
        //  RATBOX:                   <?> <?> <?> <?> <?> <?> <?> :<?>
        //sRPL_ETRACE = 709
        //  Output from 'extended' trace
        //  RATBOX:                   <?> <?> <?> <?> <?> <?> :<?>
        //sRPL_KNOCK = 710
        //  Message delivered using KNOCK command
        //  RATBOX:                   <channel> <nick>!<user>@<host> :<text>  
        //sRPL_KNOCKDLVR = 711
        //  Message returned from using KNOCK command
        //  RATBOX:                   <channel> :<text>
        //sERR_TOOMANYKNOCK = 712
        //  Message returned when too many KNOCKs for a channel have been sent by a user
        //  RATBOX:                   <channel> :<text>
        //sERR_CHANOPEN = 713
        //  Message returned from KNOCK when the channel can be freely joined by the user
        //  RATBOX:                   <channel> :<text>
        //sERR_KNOCKONCHAN = 714
        //  Message returned from KNOCK when the user has used KNOCK on a channel they have already joined
        //  RATBOX:                   <channel> :<text>
        //sERR_KNOCKDISABLED = 715
        //  Returned from KNOCK when the command has been disabled
        //  RATBOX:                   :<text>
        //sRPL_TARGUMODEG = 716
        //  Sent to indicate the given target is set +g (server-side ignore)
        //  RATBOX:                   <nick> :<info>
        //sRPL_TARGNOTIFY = 717
        //  Sent following a PRIVMSG/NOTICE to indicate the target has been notified of an attempt to talk to them while they are set +g
        //  RATBOX:                   <nick> :<info>
        //sRPL_UMODEGMSG = 718
        //  Sent to a user who is +g to inform them that someone has attempted to talk to them (via PRIVMSG/NOTICE), and that they will need to be accepted (via the ACCEPT command) before being able to talk to them
        //  RATBOX:                   <nick> <user>@<host> :<info>
        //sRPL_OMOTDSTART = 720
        //  IRC Operator MOTD header, sent upon OPER command
        //  RATBOX:                   :<text>
        //sRPL_OMOTD = 721
        //  IRC Operator MOTD text (repeated, usually)
        //  RATBOX:                   :<text>
        //sRPL_ENDOFOMOTD = 722
        //  IRC operator MOTD footer
        //  RATBOX:                   :<text>
        //sERR_NOPRIVS = 723
        //  Returned from an oper command when the IRC operator does not have the relevant operator privileges.
        //  RATBOX:                   <command> :<text>
        //sRPL_TESTMARK = 724
        //  Reply from an oper command reporting how many users match a given user@host mask
        //  RATBOX:                   <nick>!<user>@<host> <?> <?> :<text>
        //sRPL_TESTLINE = 725
        //  Reply from an oper command reporting relevant I/K lines that will match a given user@host
        //  RATBOX:                   <?> <?> <?> :<?>
        //sRPL_NOTESTLINE = 726
        //  Reply from oper command reporting no I/K lines match the given user@host
        //  RATBOX:                   <?> :<text>
        //sRPL_XINFO = 771
        //  Used to send 'eXtended info' to the client, a replacement for the STATS command to send a large variety of data and minimise numeric pollution.
        //  ITHILDIN
        //sRPL_XINFOSTART = 773
        //  Start of an RPL_XINFO list
        //  ITHILDIN
        //sRPL_XINFOEND = 774
        //  Termination of an RPL_XINFO list
        //  ITHILDIN
        //sERR_CANNOTDOCOMMAND = 972
        //  Works similarly to all of KineIRCd's CANNOT* numerics. This one indicates that a command could not be performed for an arbitrary reason. For example, a halfop Trying to kick an op.
        //  UNREAL
        //sERR_CANNOTCHANGEUMODE = 973
        //  Reply to MODE when a user cannot change a user mode
        //  KINEIRCD:                 <mode_char> :<reason>
        //sERR_CANNOTCHANGECHANMODE = 974
        //  Reply to MODE when a user cannot change a channel mode
        //  KINEIRCD:                 <mode_char> :<reason>
        //sERR_CANNOTCHANGESERVERMODE = 975
        //  Reply to MODE when a user cannot change a server mode
        //  KINEIRCD:                 <mode_char> :<reason>
        //sERR_CANNOTSENDTONICK = 976
        //  Returned from NOTICE, PRIVMSG or other commands to notify the user that they cannot send a message to a particular client. Similar to ERR_CANNOTSENDTOCHAN. KineIRCd uses this in conjunction with user-mode +R to allow users to block people who are not identified to services (spam avoidance)
        //  KINEIRCD:                 <nick> :<reason>
        //sERR_UNKNOWNSERVERMODE = 977
        //  Returned by MODE to inform the client they used an unknown server mode character.
        //  KINEIRCD:                 <modechar> :<info>
        //sERR_SERVERMODELOCK = 979
        //  Returned by MODE to inform the client the server has been set mode +L by an administrator to stop server modes being changed
        //  KINEIRCD:                 <target> :<info>
        //sERR_BADCHARENCODING = 980
        //  Returned by any command which may have had the given data modified because one or more glyphs were incorrectly encoded in the current charset (given). Such a use would be where an invalid UTF-8 sequence was given which may be considered insecure, or defines a character which is invalid within that context. For safety reasons, the invalid character is not returned to the client.
        //  KINEIRCD:                 <command> <charset> :<info>
        //sERR_TOOMANYLANGUAGES = 981
        //  Returned by the LANGUAGE command to tell the client they cannot set as many languages as they have requested. To assist the client, the maximum languages which can be set at one time is given, and the language settings are not changed.
        //  KINEIRCD:                 <max_langs> :<info>
        //sERR_NOLANGUAGE = 982
        //  Returned by the LANGUAGE command to tell the client it has specified an unknown language code.
        //  KINEIRCD:                 <language_code> :<info>
        //sERR_TEXTTOOSHORT = 983
        //  Returned by any command requiring text (such as a message or a reason), which was not long enough to be considered valid. This was created initially to combat '/wallops foo' abuse, but is also used by DIE and RESTART commands to attempt to encourage meaningful reasons.
        //  KINEIRCD:                 <command> :<info>
        sERR_NUMERIC_ERR = 999
        //  BAHAMUT:                  :%s 999 %s Numeric error! yikes!
        //sERR_NUMERICERR = 999 (CONFLICTING)
        //  UNREAL
    }
}