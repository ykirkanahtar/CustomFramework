ª
pC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\ApplicationSettings\ApiConstants.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
ApplicationSettings' :
{ 
public 

static 
class 
ApiConstants $
{ 
public 
const 
string 
DefaultRoute (
=) *
$str+ 1
;1 2
public 
const 
string 

AdminRoute &
=' (
DefaultRoute) 5
+6 7
$str8 @
;@ A
} 
} ≤
oC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\ApplicationSettings\AppSettings.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
ApplicationSettings' :
{ 
public 

class 
AppSettings 
{ 
public 
AppSettings 
( 
) 
{ 	
Token		 
=		 
new		 
Token		 
(		 
)		 
;		  
}

 	
public 
int 
DefaultListCount #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
int $
IterationCountForHashing +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
Token 
Token 
{ 
get  
;  !
set" %
;% &
}' (
} 
} Ú
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\AutoMapper\MappingProfile.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '

AutoMapper' 1
{ 
public 

class 
MappingProfile 
:  !'
AuthorizationMappingProfile" =
{		 
public

 
MappingProfile

 
(

 
)

 
{ 	
Map 
( 
) 
; 
	CreateMap 
< 
Student 
, 
StudentResponse .
>. /
(/ 0
)0 1
;1 2
	CreateMap 
< 
StudentRequest $
,$ %
Student& -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
Course 
, 
CourseResponse ,
>, -
(- .
). /
;/ 0
	CreateMap 
< 
CourseRequest #
,# $
Course% +
>+ ,
(, -
)- .
;. /
	CreateMap 
< 
Teacher 
, 
TeacherResponse .
>. /
(/ 0
)0 1
;1 2
	CreateMap 
< 
TeacherRequest $
,$ %
Teacher& -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
StudentCourse #
,# $!
StudentCourseResponse% :
>: ;
(; <
)< =
;= >
	CreateMap 
<  
StudentCourseRequest *
,* +
StudentCourse, 9
>9 :
(: ;
); <
;< =
} 	
} 
} ÁM
fC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\CourseManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public 

class 
CourseManager 
:  -
!BaseBusinessManagerWithApiRequest! B
<B C

ApiRequestC M
>M N
,N O
ICourseManagerP ^
{ 
private 
readonly 
IUnitOfWorkWebApi *
_uow+ /
;/ 0
public 
CourseManager 
( 
IUnitOfWorkWebApi .
uow/ 2
,2 3
ILogger4 ;
<; <
CourseManager< I
>I J
loggerK Q
,Q R
IMapperS Z
mapper[ a
,a b
IApiRequestAccessorc v
apiRequestAccessor	w â
)
â ä
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
Course 
> 
CreateAsync '
(' (
CourseRequest( 5
request6 =
)= >
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{   
var!! 
result!! 
=!! 
Mapper!! #
.!!# $
Map!!$ '
<!!' (
Course!!( .
>!!. /
(!!/ 0
request!!0 7
)!!7 8
;!!8 9
var%%  
courseNoUniqueResult%% (
=%%) *
await%%+ 0
_uow%%1 5
.%%5 6
Courses%%6 =
.%%= >
GetByCourseNoAsync%%> P
(%%P Q
request%%Q X
.%%X Y
CourseNo%%Y a
)%%a b
;%%b c 
courseNoUniqueResult'' $
.''$ %
CheckUniqueValue''% 5
(''5 6#
WebApiResourceConstants''6 M
.''M N
CourseNo''N V
)''V W
;''W X
_uow,, 
.,, 
Courses,, 
.,, 
Add,,  
(,,  !
result,,! '
),,' (
;,,( )
await-- 
_uow-- 
.-- 
SaveChangesAsync-- +
(--+ ,
)--, -
;--- .
return// 
result// 
;// 
}00 
,00 
new00 
BusinessBaseRequest00 &
{00' (

MethodBase00) 3
=004 5

MethodBase006 @
.00@ A
GetCurrentMethod00A Q
(00Q R
)00R S
}00T U
)00U V
;00V W
}11 	
public33 
Task33 
<33 
Course33 
>33 
UpdateAsync33 '
(33' (
int33( +
id33, .
,33. /
CourseRequest330 =
request33> E
)33E F
{44 	
return55 /
#CommonOperationWithTransactionAsync55 6
(556 7
async557 <
(55= >
)55> ?
=>55@ B
{66 
var77 
result77 
=77 
await77 "
GetByIdAsync77# /
(77/ 0
id770 2
)772 3
;773 4
Mapper88 
.88 
Map88 
(88 
request88 "
,88" #
result88$ *
)88* +
;88+ ,
var<<  
courseNoUniqueResult<< (
=<<) *
await<<+ 0
_uow<<1 5
.<<5 6
Courses<<6 =
.<<= >
GetByCourseNoAsync<<> P
(<<P Q
request<<Q X
.<<X Y
CourseNo<<Y a
)<<a b
;<<b c 
courseNoUniqueResult>> $
.>>$ %%
CheckUniqueValueForUpdate>>% >
(>>> ?
result>>? E
.>>E F
Id>>F H
,>>H I#
WebApiResourceConstants>>J a
.>>a b
CourseNo>>b j
)>>j k
;>>k l
_uowCC 
.CC 
CoursesCC 
.CC 
UpdateCC #
(CC# $
resultCC$ *
)CC* +
;CC+ ,
awaitDD 
_uowDD 
.DD 
SaveChangesAsyncDD +
(DD+ ,
)DD, -
;DD- .
returnFF 
resultFF 
;FF 
}GG 
,GG 
newGG 
BusinessBaseRequestGG &
{GG' (

MethodBaseGG) 3
=GG4 5

MethodBaseGG6 @
.GG@ A
GetCurrentMethodGGA Q
(GGQ R
)GGR S
}GGT U
)GGU V
;GGV W
}HH 	
publicLL 
TaskLL 
DeleteAsyncLL 
(LL  
intLL  #
idLL$ &
)LL& '
{MM 	
returnNN /
#CommonOperationWithTransactionAsyncNN 6
(NN6 7
asyncNN7 <
(NN= >
)NN> ?
=>NN@ B
{OO 
varPP 
resultPP 
=PP 
awaitPP "
GetByIdAsyncPP# /
(PP/ 0
idPP0 2
)PP2 3
;PP3 4
_uowRR 
.RR 
CoursesRR 
.RR 
DeleteRR #
(RR# $
resultRR$ *
)RR* +
;RR+ ,
awaitTT 
_uowTT 
.TT 
SaveChangesAsyncTT +
(TT+ ,
)TT, -
;TT- .
}UU 
,UU 
newUU 
BusinessBaseRequestUU &
{UU' (

MethodBaseUU) 3
=UU4 5

MethodBaseUU6 @
.UU@ A
GetCurrentMethodUUA Q
(UUQ R
)UUR S
}UUT U
)UUU V
;UUV W
}VV 	
publicXX 
TaskXX 
<XX 
CourseXX 
>XX 
GetByIdAsyncXX (
(XX( )
intXX) ,
idXX- /
)XX/ 0
{YY 	
returnZZ  
CommonOperationAsyncZZ '
(ZZ' (
asyncZZ( -
(ZZ. /
)ZZ/ 0
=>ZZ1 3
awaitZZ4 9
_uowZZ: >
.ZZ> ?
CoursesZZ? F
.ZZF G
GetByIdAsyncZZG S
(ZZS T
idZZT V
)ZZV W
,ZZW X
newZZY \
BusinessBaseRequestZZ] p
{ZZq r

MethodBaseZZs }
=ZZ~ 

MethodBase
ZZÄ ä
.
ZZä ã
GetCurrentMethod
ZZã õ
(
ZZõ ú
)
ZZú ù
}
ZZû ü
,
ZZü †
BusinessUtilMethod[[ "
.[[" #
CheckRecordIsExist[[# 5
,[[5 6
GetType[[7 >
([[> ?
)[[? @
.[[@ A
Name[[A E
)[[E F
;[[F G
}\\ 	
public^^ 
Task^^ 
<^^ 
Course^^ 
>^^ 
GetByCourseNoAsync^^ .
(^^. /
int^^/ 2
courseNo^^3 ;
)^^; <
{__ 	
return``  
CommonOperationAsync`` '
(``' (
async``( -
(``. /
)``/ 0
=>``1 3
await``4 9
_uow``: >
.``> ?
Courses``? F
.``F G
GetByCourseNoAsync``G Y
(``Y Z
courseNo``Z b
)``b c
,``c d
new``e h
BusinessBaseRequest``i |
{``} ~

MethodBase	`` â
=
``ä ã

MethodBase
``å ñ
.
``ñ ó
GetCurrentMethod
``ó ß
(
``ß ®
)
``® ©
}
``™ ´
,
``´ ¨
BusinessUtilMethodaa "
.aa" #
CheckRecordIsExistaa# 5
,aa5 6
GetTypeaa7 >
(aa> ?
)aa? @
.aa@ A
NameaaA E
)aaE F
;aaF G
}bb 	
publiccc 
Taskcc 
<cc 
ICustomListcc 
<cc  
Coursecc  &
>cc& '
>cc' ("
GetAllByTeacherIdAsynccc) ?
(cc? @
intcc@ C
	teacherIdccD M
)ccM N
{dd 	
returnee  
CommonOperationAsyncee '
(ee' (
asyncee( -
(ee. /
)ee/ 0
=>ee1 3
awaitee4 9
_uowee: >
.ee> ?
Coursesee? F
.eeF G"
GetAllByTeacherIdAsynceeG ]
(ee] ^
	teacherIdee^ g
)eeg h
,eeh i
neweej m 
BusinessBaseRequest	een Å
{
eeÇ É

MethodBase
eeÑ é
=
eeè ê

MethodBase
eeë õ
.
eeõ ú
GetCurrentMethod
eeú ¨
(
ee¨ ≠
)
ee≠ Æ
}
eeØ ∞
,
ee∞ ± 
BusinessUtilMethod
ee≤ ƒ
.
eeƒ ≈
CheckNothing
ee≈ —
,
ee— “
GetType
ee” ⁄
(
ee⁄ €
)
ee€ ‹
.
ee‹ ›
Name
ee› ·
)
ee· ‚
;
ee‚ „
}ff 	
publicgg 
Taskgg 
<gg 
ICustomListgg 
<gg  
Coursegg  &
>gg& '
>gg' (
GetAllAsyncgg) 4
(gg4 5
)gg5 6
{hh 	
returnii  
CommonOperationAsyncii '
(ii' (
asyncii( -
(ii. /
)ii/ 0
=>ii1 3
awaitii4 9
_uowii: >
.ii> ?
Coursesii? F
.iiF G
GetAllAsynciiG R
(iiR S
)iiS T
,iiT U
newiiV Y
BusinessBaseRequestiiZ m
{iin o

MethodBaseiip z
=ii{ |

MethodBase	ii} á
.
iiá à
GetCurrentMethod
iià ò
(
iiò ô
)
iiô ö
}
iiõ ú
,
iiú ù 
BusinessUtilMethod
iiû ∞
.
ii∞ ±
CheckNothing
ii± Ω
,
iiΩ æ
GetType
iiø ∆
(
ii∆ «
)
ii« »
.
ii» …
Name
ii… Õ
)
iiÕ Œ
;
iiŒ œ
}jj 	
}ll 
}mm ≠

gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\ICourseManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public		 

	interface		 
ICourseManager		 #
:		$ %
IBusinessManager		& 6
<		6 7
Course		7 =
,		= >
CourseRequest		? L
,		L M
int		N Q
>		Q R
,

 	"
IBusinessManagerUpdate


  
<

  !
Course

! '
,

' (
CourseRequest

) 6
,

6 7
int

8 ;
>

; <
{ 
Task 
< 
Course 
> 
GetByCourseNoAsync '
(' (
int( +
courseNo, 4
)4 5
;5 6
Task 
< 
ICustomList 
< 
Course 
>  
>  !"
GetAllByTeacherIdAsync" 8
(8 9
int9 <
	teacherId= F
)F G
;G H
Task 
< 
ICustomList 
< 
Course 
>  
>  !
GetAllAsync" -
(- .
). /
;/ 0
} 
} °
nC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\IStudentCourseManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public		 

	interface		 !
IStudentCourseManager		 *
:		+ ,
IBusinessManager		- =
<		= >
StudentCourse		> K
,		K L 
StudentCourseRequest		M a
,		a b
int		c f
>		f g
{ 
Task 
< 
ICustomList 
< 
StudentCourse &
>& '
>' ("
GetAllByStudentIdAsync) ?
(? @
int@ C
	studentIdD M
)M N
;N O
Task 
< 
ICustomList 
< 
StudentCourse &
>& '
>' (!
GetAllByCourseIdAsync) >
(> ?
int? B
courseIdC K
)K L
;L M
} 
} „

hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\IStudentManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public		 

	interface		 
IStudentManager		 $
:		% &
IBusinessManager		' 7
<		7 8
Student		8 ?
,		? @
StudentRequest		A O
,		O P
int		Q T
>		T U
,

 	"
IBusinessManagerUpdate


  
<

  !
Student

! (
,

( )
StudentRequest

* 8
,

8 9
int

: =
>

= >
{ 
Task 
< 
Student 
> 
GetByStudentNoAsync )
() *
int* -
	studentNo. 7
)7 8
;8 9
Task 
< 
ICustomList 
< 
Student  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
Task 
< 
ICustomList 
< 
Student  
>  !
>! "
GetAllAsync# .
(. /
int/ 2
	pageIndex3 <
,< =
int> A
pageSizeB J
)J K
;K L
} 
} √
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\ITeacherManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public		 

	interface		 
ITeacherManager		 $
:		% &
IBusinessManager		' 7
<		7 8
Teacher		8 ?
,		? @
TeacherRequest		A O
,		O P
int		Q T
>		T U
,

 	"
IBusinessManagerUpdate


  
<

  !
Teacher

! (
,

( )
TeacherRequest

* 8
,

8 9
int

: =
>

= >
{ 
Task 
< 
Teacher 
> 
GetByTeacherNoAsync )
() *
int* -
	teacherNo. 7
)7 8
;8 9
Task 
< 
ICustomList 
< 
Teacher  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
} 
} Ë4
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\StudentCourseManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public 

class  
StudentCourseManager %
:& '-
!BaseBusinessManagerWithApiRequest( I
<I J

ApiRequestJ T
>T U
,U V!
IStudentCourseManagerW l
{ 
private 
readonly 
IUnitOfWorkWebApi *
_uow+ /
;/ 0
public  
StudentCourseManager #
(# $
IUnitOfWorkWebApi$ 5
uow6 9
,9 :
ILogger; B
<B C 
StudentCourseManagerC W
>W X
loggerY _
,_ `
IMappera h
mapperi o
,o p 
IApiRequestAccessor	q Ñ 
apiRequestAccessor
Ö ó
)
ó ò
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
StudentCourse !
>! "
CreateAsync# .
(. / 
StudentCourseRequest/ C
requestD K
)K L
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{ 
var 
result 
= 
Mapper #
.# $
Map$ '
<' (
StudentCourse( 5
>5 6
(6 7
request7 >
)> ?
;? @
_uow## 
.## 
StudentCourses## #
.### $
Add##$ '
(##' (
result##( .
)##. /
;##/ 0
await$$ 
_uow$$ 
.$$ 
SaveChangesAsync$$ +
($$+ ,
)$$, -
;$$- .
return&& 
result&& 
;&& 
}'' 
,'' 
new'' 
BusinessBaseRequest'' &
{''' (

MethodBase'') 3
=''4 5

MethodBase''6 @
.''@ A
GetCurrentMethod''A Q
(''Q R
)''R S
}''T U
)''U V
;''V W
}(( 	
public,, 
Task,, 
DeleteAsync,, 
(,,  
int,,  #
id,,$ &
),,& '
{-- 	
return.. /
#CommonOperationWithTransactionAsync.. 6
(..6 7
async..7 <
(..= >
)..> ?
=>..@ B
{// 
var00 
result00 
=00 
await00 "
GetByIdAsync00# /
(00/ 0
id000 2
)002 3
;003 4
_uow22 
.22 
StudentCourses22 #
.22# $
Delete22$ *
(22* +
result22+ 1
)221 2
;222 3
await44 
_uow44 
.44 
SaveChangesAsync44 +
(44+ ,
)44, -
;44- .
}55 
,55 
new55 
BusinessBaseRequest55 &
{55' (

MethodBase55) 3
=554 5

MethodBase556 @
.55@ A
GetCurrentMethod55A Q
(55Q R
)55R S
}55T U
)55U V
;55V W
}66 	
public88 
Task88 
<88 
StudentCourse88 !
>88! "
GetByIdAsync88# /
(88/ 0
int880 3
id884 6
)886 7
{99 	
return::  
CommonOperationAsync:: '
(::' (
async::( -
(::. /
)::/ 0
=>::1 3
await::4 9
_uow::: >
.::> ?
StudentCourses::? M
.::M N
GetByIdAsync::N Z
(::Z [
id::[ ]
)::] ^
,::^ _
new::` c
BusinessBaseRequest::d w
{::x y

MethodBase	::z Ñ
=
::Ö Ü

MethodBase
::á ë
.
::ë í
GetCurrentMethod
::í ¢
(
::¢ £
)
::£ §
}
::• ¶
,
::¶ ß
BusinessUtilMethod;; "
.;;" #
CheckRecordIsExist;;# 5
,;;5 6
GetType;;7 >
(;;> ?
);;? @
.;;@ A
Name;;A E
);;E F
;;;F G
}<< 	
public>> 
Task>> 
<>> 
ICustomList>> 
<>> 
StudentCourse>> &
>>>& '
>>>' ("
GetAllByStudentIdAsync>>) ?
(>>? @
int>>@ C
	studentId>>D M
)>>M N
{?? 
return@@  
CommonOperationAsync@@ '
(@@' (
async@@( -
(@@. /
)@@/ 0
=>@@1 3
await@@4 9
_uow@@: >
.@@> ?
StudentCourses@@? M
.@@M N"
GetAllByStudentIdAsync@@N d
(@@d e
	studentId@@e n
)@@n o
,@@o p
new@@q t 
BusinessBaseRequest	@@u à
{
@@â ä

MethodBase
@@ã ï
=
@@ñ ó

MethodBase
@@ò ¢
.
@@¢ £
GetCurrentMethod
@@£ ≥
(
@@≥ ¥
)
@@¥ µ
}
@@∂ ∑
,
@@∑ ∏ 
BusinessUtilMethod
@@π À
.
@@À Ã
CheckNothing
@@Ã ÿ
,
@@ÿ Ÿ
GetType
@@⁄ ·
(
@@· ‚
)
@@‚ „
.
@@„ ‰
Name
@@‰ Ë
)
@@Ë È
;
@@È Í
}AA 
publicBB 
TaskBB 
<BB 
ICustomListBB 
<BB 
StudentCourseBB &
>BB& '
>BB' (!
GetAllByCourseIdAsyncBB) >
(BB> ?
intBB? B
courseIdBBC K
)BBK L
{CC 
returnDD  
CommonOperationAsyncDD '
(DD' (
asyncDD( -
(DD. /
)DD/ 0
=>DD1 3
awaitDD4 9
_uowDD: >
.DD> ?
StudentCoursesDD? M
.DDM N!
GetAllByCourseIdAsyncDDN c
(DDc d
courseIdDDd l
)DDl m
,DDm n
newDDo r 
BusinessBaseRequest	DDs Ü
{
DDá à

MethodBase
DDâ ì
=
DDî ï

MethodBase
DDñ †
.
DD† °
GetCurrentMethod
DD° ±
(
DD± ≤
)
DD≤ ≥
}
DD¥ µ
,
DDµ ∂ 
BusinessUtilMethod
DD∑ …
.
DD…  
CheckNothing
DD  ÷
,
DD÷ ◊
GetType
DDÿ ﬂ
(
DDﬂ ‡
)
DD‡ ·
.
DD· ‚
Name
DD‚ Ê
)
DDÊ Á
;
DDÁ Ë
}EE 
}GG 
}HH ’N
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\StudentManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public 

class 
StudentManager 
:  !-
!BaseBusinessManagerWithApiRequest" C
<C D

ApiRequestD N
>N O
,O P
IStudentManagerQ `
{ 
private 
readonly 
IUnitOfWorkWebApi *
_uow+ /
;/ 0
public 
StudentManager 
( 
IUnitOfWorkWebApi /
uow0 3
,3 4
ILogger5 <
<< =
StudentManager= K
>K L
loggerM S
,S T
IMapperU \
mapper] c
,c d
IApiRequestAccessore x
apiRequestAccessor	y ã
)
ã å
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
Student 
> 
CreateAsync (
(( )
StudentRequest) 7
request8 ?
)? @
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{   
var!! 
result!! 
=!! 
Mapper!! #
.!!# $
Map!!$ '
<!!' (
Student!!( /
>!!/ 0
(!!0 1
request!!1 8
)!!8 9
;!!9 :
var%% !
studentNoUniqueResult%% )
=%%* +
await%%, 1
_uow%%2 6
.%%6 7
Students%%7 ?
.%%? @
GetByStudentNoAsync%%@ S
(%%S T
request%%T [
.%%[ \
	StudentNo%%\ e
)%%e f
;%%f g!
studentNoUniqueResult'' %
.''% &
CheckUniqueValue''& 6
(''6 7#
WebApiResourceConstants''7 N
.''N O
	StudentNo''O X
)''X Y
;''Y Z
_uow,, 
.,, 
Students,, 
.,, 
Add,, !
(,,! "
result,," (
),,( )
;,,) *
await-- 
_uow-- 
.-- 
SaveChangesAsync-- +
(--+ ,
)--, -
;--- .
return// 
result// 
;// 
}00 
,00 
new00 
BusinessBaseRequest00 &
{00' (

MethodBase00) 3
=004 5

MethodBase006 @
.00@ A
GetCurrentMethod00A Q
(00Q R
)00R S
}00T U
)00U V
;00V W
}11 	
public33 
Task33 
<33 
Student33 
>33 
UpdateAsync33 (
(33( )
int33) ,
id33- /
,33/ 0
StudentRequest331 ?
request33@ G
)33G H
{44 	
return55 /
#CommonOperationWithTransactionAsync55 6
(556 7
async557 <
(55= >
)55> ?
=>55@ B
{66 
var77 
result77 
=77 
await77 "
GetByIdAsync77# /
(77/ 0
id770 2
)772 3
;773 4
Mapper88 
.88 
Map88 
(88 
request88 "
,88" #
result88$ *
)88* +
;88+ ,
var<< !
studentNoUniqueResult<< )
=<<* +
await<<, 1
_uow<<2 6
.<<6 7
Students<<7 ?
.<<? @
GetByStudentNoAsync<<@ S
(<<S T
request<<T [
.<<[ \
	StudentNo<<\ e
)<<e f
;<<f g!
studentNoUniqueResult>> %
.>>% &%
CheckUniqueValueForUpdate>>& ?
(>>? @
result>>@ F
.>>F G
Id>>G I
,>>I J#
WebApiResourceConstants>>K b
.>>b c
	StudentNo>>c l
)>>l m
;>>m n
_uowCC 
.CC 
StudentsCC 
.CC 
UpdateCC $
(CC$ %
resultCC% +
)CC+ ,
;CC, -
awaitDD 
_uowDD 
.DD 
SaveChangesAsyncDD +
(DD+ ,
)DD, -
;DD- .
returnFF 
resultFF 
;FF 
}GG 
,GG 
newGG 
BusinessBaseRequestGG &
{GG' (

MethodBaseGG) 3
=GG4 5

MethodBaseGG6 @
.GG@ A
GetCurrentMethodGGA Q
(GGQ R
)GGR S
}GGT U
)GGU V
;GGV W
}HH 	
publicLL 
TaskLL 
DeleteAsyncLL 
(LL  
intLL  #
idLL$ &
)LL& '
{MM 	
returnNN /
#CommonOperationWithTransactionAsyncNN 6
(NN6 7
asyncNN7 <
(NN= >
)NN> ?
=>NN@ B
{OO 
varPP 
resultPP 
=PP 
awaitPP "
GetByIdAsyncPP# /
(PP/ 0
idPP0 2
)PP2 3
;PP3 4
_uowRR 
.RR 
StudentsRR 
.RR 
DeleteRR $
(RR$ %
resultRR% +
)RR+ ,
;RR, -
awaitTT 
_uowTT 
.TT 
SaveChangesAsyncTT +
(TT+ ,
)TT, -
;TT- .
}UU 
,UU 
newUU 
BusinessBaseRequestUU &
{UU' (

MethodBaseUU) 3
=UU4 5

MethodBaseUU6 @
.UU@ A
GetCurrentMethodUUA Q
(UUQ R
)UUR S
}UUT U
)UUU V
;UUV W
}VV 	
publicXX 
TaskXX 
<XX 
StudentXX 
>XX 
GetByIdAsyncXX )
(XX) *
intXX* -
idXX. 0
)XX0 1
{YY 	
returnZZ  
CommonOperationAsyncZZ '
(ZZ' (
asyncZZ( -
(ZZ. /
)ZZ/ 0
=>ZZ1 3
awaitZZ4 9
_uowZZ: >
.ZZ> ?
StudentsZZ? G
.ZZG H
GetByIdAsyncZZH T
(ZZT U
idZZU W
)ZZW X
,ZZX Y
newZZZ ]
BusinessBaseRequestZZ^ q
{ZZr s

MethodBaseZZt ~
=	ZZ Ä

MethodBase
ZZÅ ã
.
ZZã å
GetCurrentMethod
ZZå ú
(
ZZú ù
)
ZZù û
}
ZZü †
,
ZZ† °
BusinessUtilMethod[[ "
.[[" #
CheckRecordIsExist[[# 5
,[[5 6
GetType[[7 >
([[> ?
)[[? @
.[[@ A
Name[[A E
)[[E F
;[[F G
}\\ 	
public^^ 
Task^^ 
<^^ 
Student^^ 
>^^ 
GetByStudentNoAsync^^ 0
(^^0 1
int^^1 4
	studentNo^^5 >
)^^> ?
{__ 	
return``  
CommonOperationAsync`` '
(``' (
async``( -
(``. /
)``/ 0
=>``1 3
await``4 9
_uow``: >
.``> ?
Students``? G
.``G H
GetByStudentNoAsync``H [
(``[ \
	studentNo``\ e
)``e f
,``f g
new``h k
BusinessBaseRequest``l 
{
``Ä Å

MethodBase
``Ç å
=
``ç é

MethodBase
``è ô
.
``ô ö
GetCurrentMethod
``ö ™
(
``™ ´
)
``´ ¨
}
``≠ Æ
,
``Æ Ø
BusinessUtilMethodaa "
.aa" #
CheckRecordIsExistaa# 5
,aa5 6
GetTypeaa7 >
(aa> ?
)aa? @
.aa@ A
NameaaA E
)aaE F
;aaF G
}bb 	
publiccc 
Taskcc 
<cc 
ICustomListcc 
<cc  
Studentcc  '
>cc' (
>cc( )
GetAllAsynccc* 5
(cc5 6
)cc6 7
{dd 	
returnee  
CommonOperationAsyncee '
(ee' (
asyncee( -
(ee. /
)ee/ 0
=>ee1 3
awaitee4 9
_uowee: >
.ee> ?
Studentsee? G
.eeG H
GetAllAsynceeH S
(eeS T
)eeT U
,eeU V
neweeW Z
BusinessBaseRequestee[ n
{eeo p

MethodBaseeeq {
=ee| }

MethodBase	ee~ à
.
eeà â
GetCurrentMethod
eeâ ô
(
eeô ö
)
eeö õ
}
eeú ù
,
eeù û 
BusinessUtilMethod
eeü ±
.
ee± ≤
CheckNothing
ee≤ æ
,
eeæ ø
GetType
ee¿ «
(
ee« »
)
ee» …
.
ee…  
Name
ee  Œ
)
eeŒ œ
;
eeœ –
}ff 	
publicgg 
Taskgg 
<gg 
ICustomListgg 
<gg  
Studentgg  '
>gg' (
>gg( )
GetAllAsyncgg* 5
(gg5 6
intgg6 9
	pageIndexgg: C
,ggC D
intggE H
pageSizeggI Q
)ggQ R
{hh 	
returnii  
CommonOperationAsyncii '
(ii' (
asyncii( -
(ii. /
)ii/ 0
=>ii1 3
awaitii4 9
_uowii: >
.ii> ?
Studentsii? G
.iiG H
GetAllAsynciiH S
(iiS T
	pageIndexiiT ]
,ii] ^
pageSizeii_ g
)iig h
,iih i
newiij m 
BusinessBaseRequest	iin Å
{
iiÇ É

MethodBase
iiÑ é
=
iiè ê

MethodBase
iië õ
.
iiõ ú
GetCurrentMethod
iiú ¨
(
ii¨ ≠
)
ii≠ Æ
}
iiØ ∞
,
ii∞ ± 
BusinessUtilMethod
ii≤ ƒ
.
iiƒ ≈
CheckNothing
ii≈ —
,
ii— “
GetType
ii” ⁄
(
ii⁄ €
)
ii€ ‹
.
ii‹ ›
Name
ii› ·
)
ii· ‚
;
ii‚ „
}jj 	
}ll 
}mm ”E
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Business\TeacherManager.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Business' /
{ 
public 

class 
TeacherManager 
:  !-
!BaseBusinessManagerWithApiRequest" C
<C D

ApiRequestD N
>N O
,O P
ITeacherManagerQ `
{ 
private 
readonly 
IUnitOfWorkWebApi *
_uow+ /
;/ 0
public 
TeacherManager 
( 
IUnitOfWorkWebApi /
uow0 3
,3 4
ILogger5 <
<< =
TeacherManager= K
>K L
loggerM S
,S T
IMapperU \
mapper] c
,c d
IApiRequestAccessore x
apiRequestAccessor	y ã
)
ã å
: 
base 
( 
logger 
, 
mapper !
,! "
apiRequestAccessor# 5
)5 6
{ 	
_uow 
= 
uow 
; 
} 	
public 
Task 
< 
Teacher 
> 
CreateAsync (
(( )
TeacherRequest) 7
request8 ?
)? @
{ 	
return /
#CommonOperationWithTransactionAsync 6
(6 7
async7 <
(= >
)> ?
=>@ B
{   
var!! 
result!! 
=!! 
Mapper!! #
.!!# $
Map!!$ '
<!!' (
Teacher!!( /
>!!/ 0
(!!0 1
request!!1 8
)!!8 9
;!!9 :
var%% !
teacherNoUniqueResult%% )
=%%* +
await%%, 1
_uow%%2 6
.%%6 7
Teachers%%7 ?
.%%? @
GetByTeacherNoAsync%%@ S
(%%S T
request%%T [
.%%[ \
	TeacherNo%%\ e
)%%e f
;%%f g!
teacherNoUniqueResult'' %
.''% &
CheckUniqueValue''& 6
(''6 7#
WebApiResourceConstants''7 N
.''N O
	TeacherNo''O X
)''X Y
;''Y Z
_uow,, 
.,, 
Teachers,, 
.,, 
Add,, !
(,,! "
result,," (
),,( )
;,,) *
await-- 
_uow-- 
.-- 
SaveChangesAsync-- +
(--+ ,
)--, -
;--- .
return// 
result// 
;// 
}00 
,00 
new00 
BusinessBaseRequest00 &
{00' (

MethodBase00) 3
=004 5

MethodBase006 @
.00@ A
GetCurrentMethod00A Q
(00Q R
)00R S
}00T U
)00U V
;00V W
}11 	
public33 
Task33 
<33 
Teacher33 
>33 
UpdateAsync33 (
(33( )
int33) ,
id33- /
,33/ 0
TeacherRequest331 ?
request33@ G
)33G H
{44 	
return55 /
#CommonOperationWithTransactionAsync55 6
(556 7
async557 <
(55= >
)55> ?
=>55@ B
{66 
var77 
result77 
=77 
await77 "
GetByIdAsync77# /
(77/ 0
id770 2
)772 3
;773 4
Mapper88 
.88 
Map88 
(88 
request88 "
,88" #
result88$ *
)88* +
;88+ ,
var<< !
teacherNoUniqueResult<< )
=<<* +
await<<, 1
_uow<<2 6
.<<6 7
Teachers<<7 ?
.<<? @
GetByTeacherNoAsync<<@ S
(<<S T
request<<T [
.<<[ \
	TeacherNo<<\ e
)<<e f
;<<f g!
teacherNoUniqueResult>> %
.>>% &%
CheckUniqueValueForUpdate>>& ?
(>>? @
result>>@ F
.>>F G
Id>>G I
,>>I J#
WebApiResourceConstants>>K b
.>>b c
	TeacherNo>>c l
)>>l m
;>>m n
_uowCC 
.CC 
TeachersCC 
.CC 
UpdateCC $
(CC$ %
resultCC% +
)CC+ ,
;CC, -
awaitDD 
_uowDD 
.DD 
SaveChangesAsyncDD +
(DD+ ,
)DD, -
;DD- .
returnFF 
resultFF 
;FF 
}GG 
,GG 
newGG 
BusinessBaseRequestGG &
{GG' (

MethodBaseGG) 3
=GG4 5

MethodBaseGG6 @
.GG@ A
GetCurrentMethodGGA Q
(GGQ R
)GGR S
}GGT U
)GGU V
;GGV W
}HH 	
publicLL 
TaskLL 
DeleteAsyncLL 
(LL  
intLL  #
idLL$ &
)LL& '
{MM 	
returnNN /
#CommonOperationWithTransactionAsyncNN 6
(NN6 7
asyncNN7 <
(NN= >
)NN> ?
=>NN@ B
{OO 
varPP 
resultPP 
=PP 
awaitPP "
GetByIdAsyncPP# /
(PP/ 0
idPP0 2
)PP2 3
;PP3 4
_uowRR 
.RR 
TeachersRR 
.RR 
DeleteRR $
(RR$ %
resultRR% +
)RR+ ,
;RR, -
awaitTT 
_uowTT 
.TT 
SaveChangesAsyncTT +
(TT+ ,
)TT, -
;TT- .
}UU 
,UU 
newUU 
BusinessBaseRequestUU &
{UU' (

MethodBaseUU) 3
=UU4 5

MethodBaseUU6 @
.UU@ A
GetCurrentMethodUUA Q
(UUQ R
)UUR S
}UUT U
)UUU V
;UUV W
}VV 	
publicXX 
TaskXX 
<XX 
TeacherXX 
>XX 
GetByIdAsyncXX )
(XX) *
intXX* -
idXX. 0
)XX0 1
{YY 	
returnZZ  
CommonOperationAsyncZZ '
(ZZ' (
asyncZZ( -
(ZZ. /
)ZZ/ 0
=>ZZ1 3
awaitZZ4 9
_uowZZ: >
.ZZ> ?
TeachersZZ? G
.ZZG H
GetByIdAsyncZZH T
(ZZT U
idZZU W
)ZZW X
,ZZX Y
newZZZ ]
BusinessBaseRequestZZ^ q
{ZZr s

MethodBaseZZt ~
=	ZZ Ä

MethodBase
ZZÅ ã
.
ZZã å
GetCurrentMethod
ZZå ú
(
ZZú ù
)
ZZù û
}
ZZü †
,
ZZ† °
BusinessUtilMethod[[ "
.[[" #
CheckRecordIsExist[[# 5
,[[5 6
GetType[[7 >
([[> ?
)[[? @
.[[@ A
Name[[A E
)[[E F
;[[F G
}\\ 	
public^^ 
Task^^ 
<^^ 
Teacher^^ 
>^^ 
GetByTeacherNoAsync^^ 0
(^^0 1
int^^1 4
	teacherNo^^5 >
)^^> ?
{__ 	
return``  
CommonOperationAsync`` '
(``' (
async``( -
(``. /
)``/ 0
=>``1 3
await``4 9
_uow``: >
.``> ?
Teachers``? G
.``G H
GetByTeacherNoAsync``H [
(``[ \
	teacherNo``\ e
)``e f
,``f g
new``h k
BusinessBaseRequest``l 
{
``Ä Å

MethodBase
``Ç å
=
``ç é

MethodBase
``è ô
.
``ô ö
GetCurrentMethod
``ö ™
(
``™ ´
)
``´ ¨
}
``≠ Æ
,
``Æ Ø
BusinessUtilMethodaa "
.aa" #
CheckRecordIsExistaa# 5
,aa5 6
GetTypeaa7 >
(aa> ?
)aa? @
.aa@ A
NameaaA E
)aaE F
;aaF G
}bb 	
publiccc 
Taskcc 
<cc 
ICustomListcc 
<cc  
Teachercc  '
>cc' (
>cc( )
GetAllAsynccc* 5
(cc5 6
)cc6 7
{dd 	
returnee  
CommonOperationAsyncee '
(ee' (
asyncee( -
(ee. /
)ee/ 0
=>ee1 3
awaitee4 9
_uowee: >
.ee> ?
Teachersee? G
.eeG H
GetAllAsynceeH S
(eeS T
)eeT U
,eeU V
neweeW Z
BusinessBaseRequestee[ n
{eeo p

MethodBaseeeq {
=ee| }

MethodBase	ee~ à
.
eeà â
GetCurrentMethod
eeâ ô
(
eeô ö
)
eeö õ
}
eeú ù
,
eeù û 
BusinessUtilMethod
eeü ±
.
ee± ≤
CheckNothing
ee≤ æ
,
eeæ ø
GetType
ee¿ «
(
ee« »
)
ee» …
.
ee…  
Name
ee  Œ
)
eeŒ œ
;
eeœ –
}ff 	
}hh 
}ii ì
qC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Constants\WebApiResourceConstants.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Constants' 0
{ 
public 

static 
class #
WebApiResourceConstants /
{ 
public 
const 
string 
	StudentNo %
=& '
$str( 3
;3 4
public 
const 
string 
Name  
=! "
$str# )
;) *
public 
const 
string 
Surname #
=$ %
$str& /
;/ 0
public

 
const

 
string

 
CourseNo

 $
=

% &
$str

' 1
;

1 2
public 
const 
string 
	TeacherId %
=& '
$str( 3
;3 4
public 
const 
string 
	TeacherNo %
=& '
$str( 3
;3 4
public 
const 
string 
	StudentId %
=& '
$str( 3
;3 4
public 
const 
string 
CourseId $
=% &
$str' 1
;1 2
} 
} ≈
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\ClaimController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
Claim, 1
)1 2
)2 3
]3 4
public 

class 
ClaimController  
:! "
BaseClaimController# 6
{ 
public 
ClaimController 
( 
IClaimManager ,
claimManager- 9
,9 : 
ILocalizationService; O
localizationServiceP c
,c d
ILoggere l
<l m
ClaimControllerm |
>| }
logger	~ Ñ
,
Ñ Ö
IMapper
Ü ç
mapper
é î
)
î ï
: 
base 
( 
claimManager 
,  
localizationService! 4
,4 5
logger6 <
,< =
mapper> D
)D E
{ 	
} 	
} 
} æ
ÖC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\ClientApplicationController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
ClientApplication, =
)= >
)> ?
]? @
public 

class '
ClientApplicationController ,
:- .+
BaseClientApplicationController/ N
{ 
public '
ClientApplicationController *
(* +%
IClientApplicationManager+ D$
clientApplicationManagerE ]
,] ^ 
ILocalizationService_ s 
localizationService	t á
,
á à
ILogger
â ê
<
ê ë)
ClientApplicationController
ë ¨
>
¨ ≠
logger
Æ ¥
,
¥ µ
IMapper
∂ Ω
mapper
æ ƒ
)
ƒ ≈
: 
base 
( $
clientApplicationManager +
,+ ,
localizationService- @
,@ A
loggerB H
,H I
mapperJ P
)P Q
{ 	
} 	
} 
} Ì
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\RoleClaimController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
	RoleClaim, 5
)5 6
)6 7
]7 8
public 

class 
RoleClaimController $
:% &#
BaseRoleClaimController' >
{ 
public 
RoleClaimController "
(" #
IRoleClaimManager# 4
roleClaimManager5 E
,E F 
ILocalizationServiceG [
localizationService\ o
,o p
ILoggerq x
<x y 
RoleClaimController	y å
>
å ç
logger
é î
,
î ï
IMapper
ñ ù
mapper
û §
)
§ •
: 
base 
( 
roleClaimManager #
,# $
localizationService% 8
,8 9
logger: @
,@ A
mapperB H
)H I
{ 	
} 	
} 
} º
xC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\RoleController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
Role, 0
)0 1
)1 2
]2 3
public 

class 
RoleController 
:  !
BaseRoleController" 4
{ 
public 
RoleController 
( 
IRoleManager *
roleManager+ 6
,6 7 
ILocalizationService8 L
localizationServiceM `
,` a
ILoggerb i
<i j
RoleControllerj x
>x y
logger	z Ä
,
Ä Å
IMapper
Ç â
mapper
ä ê
)
ê ë
: 
base 
( 
roleManager 
, 
localizationService  3
,3 4
logger5 ;
,; <
mapper= C
)C D
{ 	
} 	
} 
} ¨
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\RoleEntityClaimController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
RoleEntityClaim, ;
); <
)< =
]= >
public 

class %
RoleEntityClaimController *
:+ ,)
BaseRoleEntityClaimController- J
{ 
public %
RoleEntityClaimController (
(( )#
IRoleEntityClaimManager) @"
roleEntityClaimManagerA W
,W X 
ILocalizationServiceY m 
localizationService	n Å
,
Å Ç
ILogger
É ä
<
ä ã'
RoleEntityClaimController
ã §
>
§ •
logger
¶ ¨
,
¨ ≠
IMapper
Æ µ
mapper
∂ º
)
º Ω
: 
base 
( "
roleEntityClaimManager )
,) *
localizationService+ >
,> ?
logger@ F
,F G
mapperH N
)N O
{ 	
} 	
} 
} Ω
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\TokenController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 
DefaultRoute $
+% &
$str' .
). /
]/ 0
public 

class 
TokenController  
:! "
BaseTokenController# 6
{ 
public 
TokenController 
( %
IClientApplicationManager 8$
clientApplicationManager9 Q
,Q R
IUserManagerS _
userManager` k
,k l!
ILocalizationService	m Å!
localizationService
Ç ï
,
ï ñ
ILogger
ó û
<
û ü
TokenController
ü Æ
>
Æ Ø
logger
∞ ∂
)
∂ ∑
: 
base 
( $
clientApplicationManager +
,+ ,
userManager- 8
,8 9
localizationService: M
,M N
loggerO U
,U V
StartupW ^
.^ _
AppSettings_ j
.j k
Tokenk p
)p q
{ 	
} 	
} 
} Ì
}C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\UserClaimController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
	UserClaim, 5
)5 6
)6 7
]7 8
public 

class 
UserClaimController $
:% &#
BaseUserClaimController' >
{ 
public 
UserClaimController "
(" #
IUserClaimManager# 4
userClaimManager5 E
,E F 
ILocalizationServiceG [
localizationService\ o
,o p
ILoggerq x
<x y 
UserClaimController	y å
>
å ç
logger
é î
,
î ï
IMapper
ñ ù
mapper
û §
)
§ •
: 
base 
( 
userClaimManager #
,# $
localizationService% 8
,8 9
logger: @
,@ A
mapperB H
)H I
{ 	
} 	
} 
} ±
xC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\UserController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
WebApiUtils, 7
.7 8
Authorization8 E
.E F
ModelsF L
.L M
UserM Q
)Q R
)R S
]S T
public 

class 
UserController 
:  !
BaseUserController" 4
{ 
public 
UserController 
( 
IUserManager *
userManager+ 6
,6 7 
ILocalizationService8 L
localizationServiceM `
,` a
ILoggerb i
<i j
UserControllerj x
>x y
logger	z Ä
,
Ä Å
IMapper
Ç â
mapper
ä ê
)
ê ë
: 
base 
( 
userManager 
, 
localizationService  3
,3 4
logger5 ;
,; <
mapper= C
)C D
{ 	
} 	
} 
} ¨
ÉC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\UserEntityClaimController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
UserEntityClaim, ;
); <
)< =
]= >
public 

class %
UserEntityClaimController *
:+ ,)
BaseUserEntityClaimController- J
{ 
public %
UserEntityClaimController (
(( )#
IUserEntityClaimManager) @"
userEntityClaimManagerA W
,W X 
ILocalizationServiceY m 
localizationService	n Å
,
Å Ç
ILogger
É ä
<
ä ã'
UserEntityClaimController
ã §
>
§ •
logger
¶ ¨
,
¨ ≠
IMapper
Æ µ
mapper
∂ º
)
º Ω
: 
base 
( "
userEntityClaimManager )
,) *
localizationService+ >
,> ?
logger@ F
,F G
mapperH N
)N O
{ 	
} 	
} 
} ‰
|C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\Authorization\UserRoleController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
.2 3
Authorization3 @
{ 
[ 
ApiExplorerSettings 
( 
	IgnoreApi "
=# $
false% *
)* +
]+ ,
[ 
Route 

(
 
ApiConstants 
. 

AdminRoute "
+# $
nameof% +
(+ ,
UserRole, 4
)4 5
)5 6
]6 7
public 

class 
UserRoleController #
:$ %"
BaseUserRoleController& <
{ 
public 
UserRoleController !
(! "
IUserRoleManager" 2
userRoleManager3 B
,B C 
ILocalizationServiceD X
localizationServiceY l
,l m
ILoggern u
<u v
UserRoleController	v à
>
à â
logger
ä ê
,
ê ë
IMapper
í ô
mapper
ö †
)
† °
: 
base 
( 
userRoleManager "
," #
localizationService$ 7
,7 8
logger9 ?
,? @
mapperA G
)G H
{ 	
} 	
} 
} ÿE
lC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\CourseController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
{ 
[ 
Route 

(
 
ApiConstants 
. 
DefaultRoute $
+% &
nameof' -
(- .
Course. 4
)4 5
)5 6
]6 7
public 

class 
CourseController !
:" #4
(BaseControllerWithAuthorizationAndUpdate$ L
<L M
CourseM S
,S T
CourseRequestU b
,b c
CourseRequestd q
,q r
CourseResponse	s Å
,
Å Ç
ICourseManager
É ë
,
ë í
int
ì ñ
>
ñ ó
{ 
public 
CourseController 
(  
ICourseManager  .
courseManager/ <
,< = 
ILocalizationService> R
localizationServiceS f
,f g
ILoggerh o
<o p
CourseController	p Ä
>
Ä Å
logger
Ç à
,
à â
IMapper
ä ë
mapper
í ò
)
ò ô
: 	
base
 
( 
courseManager 
, 
localizationService 1
,1 2
logger3 9
,9 :
mapper; A
)A B
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
Course !
)! "
," #
Crud$ (
.( )
Create) /
)/ 0
]0 1
public   
async   
Task   
<   
IActionResult   '
>  ' (
Create  ) /
(  / 0
[  0 1
FromBody  1 9
]  9 :
CourseRequest  ; H
request  I P
)  P Q
{!! 	
return"" 
await"" 

BaseCreate"" #
(""# $
request""$ +
)""+ ,
;"", -
}## 	
[%% 	
Route%%	 
(%% 
$str%%  
)%%  !
]%%! "
[&& 	
HttpPut&&	 
]&& 
['' 	

Permission''	 
('' 
nameof'' 
('' 
Course'' !
)''! "
,''" #
Crud''$ (
.''( )
Update'') /
)''/ 0
]''0 1
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' (
Update(() /
(((/ 0
int((0 3
id((4 6
,((6 7
[((8 9
FromBody((9 A
]((A B
CourseRequest((C P
request((Q X
)((X Y
{)) 	
return** 
await** 

BaseUpdate** #
(**# $
id**$ &
,**& '
request**( /
)**/ 0
;**0 1
}++ 	
[.. 	
Route..	 
(.. 
$str..  
)..  !
]..! "
[// 	

HttpDelete//	 
]// 
[00 	

Permission00	 
(00 
nameof00 
(00 
Course00 !
)00! "
,00" #
Crud00$ (
.00( )
Delete00) /
)00/ 0
]000 1
public11 
async11 
Task11 
<11 
IActionResult11 '
>11' (
Delete11) /
(11/ 0
int110 3
id114 6
)116 7
{22 	
return33 
await33 

BaseDelete33 #
(33# $
id33$ &
)33& '
;33' (
}44 	
[66 	
Route66	 
(66 
$str66  
)66  !
]66! "
[77 	
HttpGet77	 
]77 
[88 	

Permission88	 
(88 
nameof88 
(88 
Course88 !
)88! "
,88" #
Crud88$ (
.88( )
Select88) /
)88/ 0
]880 1
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
GetById99) 0
(990 1
int991 4
id995 7
)997 8
{:: 	
return;; 
await;; 
BaseGetById;; $
(;;$ %
id;;% '
);;' (
;;;( )
}<< 	
[>> 	
Route>>	 
(>> 
$str>> ,
)>>, -
]>>- .
[?? 	
HttpGet??	 
]?? 
[@@ 	

Permission@@	 
(@@ 
nameof@@ 
(@@ 
Course@@ !
)@@! "
,@@" #
Crud@@$ (
.@@( )
Select@@) /
)@@/ 0
]@@0 1
publicAA 
asyncAA 
TaskAA 
<AA 
IActionResultAA '
>AA' (
GetByCourseNoAA) 6
(AA6 7
intAA7 :
courseNoAA; C
)AAC D
{BB 	
varCC 
resultCC 
=CC 
awaitCC 
ManagerCC &
.CC& '
GetByCourseNoAsyncCC' 9
(CC9 :
courseNoCC: B
)CCB C
;CCC D
returnDD 
OkDD 
(DD 
newDD 
ApiResponseDD %
(DD% &
LocalizationServiceDD& 9
,DD9 :
LoggerDD; A
)DDA B
.DDB C
OkDDC E
(DDE F
MapperDDF L
.DDL M
MapDDM P
<DDP Q
CourseDDQ W
,DDW X
CourseResponseDDY g
>DDg h
(DDh i
resultDDi o
)DDo p
)DDp q
)DDq r
;DDr s
}EE 	
[FF 	
RouteFF	 
(FF 
$strFF 1
)FF1 2
]FF2 3
[GG 	
HttpGetGG	 
]GG 
[HH 	

PermissionHH	 
(HH 
nameofHH 
(HH 
CourseHH !
)HH! "
,HH" #
CrudHH$ (
.HH( )
SelectHH) /
)HH/ 0
]HH0 1
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (
GetAllByTeacherIdII) :
(II: ;
intII; >
	teacherIdII? H
)IIH I
{JJ 	
varKK 
resultKK 
=KK 
awaitKK 
ManagerKK &
.KK& '"
GetAllByTeacherIdAsyncKK' =
(KK= >
	teacherIdKK> G
)KKG H
;KKH I
returnLL 
OkLL 
(LL 
newLL 
ApiResponseLL %
(LL% &
LocalizationServiceLL& 9
,LL9 :
LoggerLL; A
)LLA B
.LLB C
OkLLC E
(LLE F
MapperMM 
.MM 
MapMM 
<MM 
IListMM  
<MM  !
CourseMM! '
>MM' (
,MM( )
IListMM* /
<MM/ 0
CourseResponseMM0 >
>MM> ?
>MM? @
(MM@ A
resultMMA G
.MMG H

ResultListMMH R
)MMR S
,MMS T
resultMMU [
.MM[ \
CountMM\ a
)MMa b
)MMb c
;MMc d
}NN 	
[OO 	
RouteOO	 
(OO 
$strOO 
)OO 
]OO 
[PP 	
HttpGetPP	 
]PP 
[QQ 	

PermissionQQ	 
(QQ 
nameofQQ 
(QQ 
CourseQQ !
)QQ! "
,QQ" #
CrudQQ$ (
.QQ( )
SelectQQ) /
)QQ/ 0
]QQ0 1
publicRR 
asyncRR 
TaskRR 
<RR 
IActionResultRR '
>RR' (
GetAllRR) /
(RR/ 0
)RR0 1
{SS 	
varTT 
resultTT 
=TT 
awaitTT 
ManagerTT &
.TT& '
GetAllAsyncTT' 2
(TT2 3
)TT3 4
;TT4 5
returnUU 
OkUU 
(UU 
newUU 
ApiResponseUU %
(UU% &
LocalizationServiceUU& 9
,UU9 :
LoggerUU; A
)UUA B
.UUB C
OkUUC E
(UUE F
MapperVV 
.VV 
MapVV 
<VV 
IEnumerableVV &
<VV& '
CourseVV' -
>VV- .
,VV. /
IEnumerableVV0 ;
<VV; <
CourseResponseVV< J
>VVJ K
>VVK L
(VVL M
resultVVM S
.VVS T

ResultListVVT ^
)VV^ _
,VV_ `
resultVVa g
.VVg h
CountVVh m
)VVm n
)VVn o
;VVo p
}WW 	
}YY 
}ZZ ˛F
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\StudentController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
{ 
[ 
Route 

(
 
ApiConstants 
. 
DefaultRoute $
+% &
nameof' -
(- .
Student. 5
)5 6
)6 7
]7 8
public 

class 
StudentController "
:# $4
(BaseControllerWithAuthorizationAndUpdate% M
<M N
StudentN U
,U V
StudentRequestW e
,e f
StudentRequestg u
,u v
StudentResponse	w Ü
,
Ü á
IStudentManager
à ó
,
ó ò
int
ô ú
>
ú ù
{ 
public 
StudentController  
(  !
IStudentManager! 0
studentManager1 ?
,? @ 
ILocalizationServiceA U
localizationServiceV i
,i j
ILoggerk r
<r s
StudentController	s Ñ
>
Ñ Ö
logger
Ü å
,
å ç
IMapper
é ï
mapper
ñ ú
)
ú ù
: 	
base
 
( 
studentManager 
, 
localizationService 2
,2 3
logger4 :
,: ;
mapper< B
)B C
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[   	

Permission  	 
(   
nameof   
(   
Student   "
)  " #
,  # $
Crud  % )
.  ) *
Create  * 0
)  0 1
]  1 2
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
Create!!) /
(!!/ 0
[!!0 1
FromBody!!1 9
]!!9 :
StudentRequest!!; I
request!!J Q
)!!Q R
{"" 	
return## 
await## 

BaseCreate## #
(### $
request##$ +
)##+ ,
;##, -
}$$ 	
[&& 	
Route&&	 
(&& 
$str&&  
)&&  !
]&&! "
['' 	
HttpPut''	 
]'' 
[(( 	

Permission((	 
((( 
nameof(( 
((( 
Student(( "
)((" #
,((# $
Crud((% )
.(() *
Update((* 0
)((0 1
]((1 2
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
Update))) /
())/ 0
int))0 3
id))4 6
,))6 7
[))8 9
FromBody))9 A
]))A B
StudentRequest))C Q
request))R Y
)))Y Z
{** 	
return++ 
await++ 

BaseUpdate++ #
(++# $
id++$ &
,++& '
request++( /
)++/ 0
;++0 1
},, 	
[// 	
Route//	 
(// 
$str//  
)//  !
]//! "
[00 	

HttpDelete00	 
]00 
[11 	

Permission11	 
(11 
nameof11 
(11 
Student11 "
)11" #
,11# $
Crud11% )
.11) *
Delete11* 0
)110 1
]111 2
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
Delete22) /
(22/ 0
int220 3
id224 6
)226 7
{33 	
return44 
await44 

BaseDelete44 #
(44# $
id44$ &
)44& '
;44' (
}55 	
[77 	
Route77	 
(77 
$str77  
)77  !
]77! "
[88 	
HttpGet88	 
]88 
[99 	

Permission99	 
(99 
nameof99 
(99 
Student99 "
)99" #
,99# $
Crud99% )
.99) *
Select99* 0
)990 1
]991 2
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
GetById::) 0
(::0 1
int::1 4
id::5 7
)::7 8
{;; 	
return<< 
await<< 
BaseGetById<< $
(<<$ %
id<<% '
)<<' (
;<<( )
}== 	
[?? 	
Route??	 
(?? 
$str?? .
)??. /
]??/ 0
[@@ 	
HttpGet@@	 
]@@ 
[AA 	

PermissionAA	 
(AA 
nameofAA 
(AA 
StudentAA "
)AA" #
,AA# $
CrudAA% )
.AA) *
SelectAA* 0
)AA0 1
]AA1 2
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
GetByStudentNoBB) 7
(BB7 8
intBB8 ;
	studentNoBB< E
)BBE F
{CC 	
varDD 
resultDD 
=DD 
awaitDD 
ManagerDD &
.DD& '
GetByStudentNoAsyncDD' :
(DD: ;
	studentNoDD; D
)DDD E
;DDE F
returnEE 
OkEE 
(EE 
newEE 
ApiResponseEE %
(EE% &
LocalizationServiceEE& 9
,EE9 :
LoggerEE; A
)EEA B
.EEB C
OkEEC E
(EEE F
MapperEEF L
.EEL M
MapEEM P
<EEP Q
StudentEEQ X
,EEX Y
StudentResponseEEZ i
>EEi j
(EEj k
resultEEk q
)EEq r
)EEr s
)EEs t
;EEt u
}FF 	
[GG 	
RouteGG	 
(GG 
$strGG 
)GG 
]GG 
[HH 	
HttpGetHH	 
]HH 
[II 	

PermissionII	 
(II 
nameofII 
(II 
StudentII "
)II" #
,II# $
CrudII% )
.II) *
SelectII* 0
)II0 1
]II1 2
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
IActionResultJJ '
>JJ' (
GetAllJJ) /
(JJ/ 0
)JJ0 1
{KK 	
varLL 
resultLL 
=LL 
awaitLL 
ManagerLL &
.LL& '
GetAllAsyncLL' 2
(LL2 3
)LL3 4
;LL4 5
returnMM 
OkMM 
(MM 
newMM 
ApiResponseMM %
(MM% &
LocalizationServiceMM& 9
,MM9 :
LoggerMM; A
)MMA B
.MMB C
OkMMC E
(MME F
MapperNN 
.NN 
MapNN 
<NN 
IEnumerableNN &
<NN& '
StudentNN' .
>NN. /
,NN/ 0
IEnumerableNN1 <
<NN< =
StudentResponseNN= L
>NNL M
>NNM N
(NNN O
resultNNO U
.NNU V

ResultListNNV `
)NN` a
,NNa b
resultNNc i
.NNi j
CountNNj o
)NNo p
)NNp q
;NNq r
}OO 	
[PP 	
RoutePP	 
(PP 
$strPP I
)PPI J
]PPJ K
[QQ 	
HttpGetQQ	 
]QQ 
[RR 	

PermissionRR	 
(RR 
nameofRR 
(RR 
StudentRR "
)RR" #
,RR# $
CrudRR% )
.RR) *
SelectRR* 0
)RR0 1
]RR1 2
publicSS 
asyncSS 
TaskSS 
<SS 
IActionResultSS '
>SS' (
GetAllSS) /
(SS/ 0
intSS0 3
	pageIndexSS4 =
,SS= >
intSS? B
pageSizeSSC K
)SSK L
{TT 	
varUU 
resultUU 
=UU 
awaitUU 
ManagerUU &
.UU& '
GetAllAsyncUU' 2
(UU2 3
	pageIndexUU3 <
,UU< =
pageSizeUU> F
)UUF G
;UUG H
returnVV 
OkVV 
(VV 
newVV 
ApiResponseVV %
(VV% &
LocalizationServiceVV& 9
,VV9 :
LoggerVV; A
)VVA B
.VVB C
OkVVC E
(VVE F
MapperWW 
.WW 
MapWW 
<WW 
IListWW  
<WW  !
StudentWW! (
>WW( )
,WW) *
IListWW+ 0
<WW0 1
StudentResponseWW1 @
>WW@ A
>WWA B
(WWB C
resultWWC I
.WWI J

ResultListWWJ T
.WWT U
ToListWWU [
(WW[ \
)WW\ ]
)WW] ^
,WW^ _
resultWW` f
.WWf g
CountWWg l
)WWl m
)WWm n
;WWn o
}XX 	
}ZZ 
}[[ ì6
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\StudentCourseController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
{ 
[ 
Route 

(
 
ApiConstants 
. 
DefaultRoute $
+% &
nameof' -
(- .
StudentCourse. ;
); <
)< =
]= >
public 

class #
StudentCourseController (
:) *+
BaseControllerWithAuthorization+ J
<J K
StudentCourseK X
,X Y 
StudentCourseRequestZ n
,n o"
StudentCourseResponse	p Ö
,
Ö Ü#
IStudentCourseManager
á ú
,
ú ù
int
û °
>
° ¢
{ 
public #
StudentCourseController &
(& '!
IStudentCourseManager' < 
studentcourseManager= Q
,Q R 
ILocalizationServiceS g
localizationServiceh {
,{ |
ILogger	} Ñ
<
Ñ Ö%
StudentCourseController
Ö ú
>
ú ù
logger
û §
,
§ •
IMapper
¶ ≠
mapper
Æ ¥
)
¥ µ
: 	
base
 
(  
studentcourseManager #
,# $
localizationService% 8
,8 9
logger: @
,@ A
mapperB H
)H I
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[ 	

Permission	 
( 
nameof 
( 
StudentCourse (
)( )
,) *
Crud+ /
./ 0
Create0 6
)6 7
]7 8
public   
async   
Task   
<   
IActionResult   '
>  ' (
Create  ) /
(  / 0
[  0 1
FromBody  1 9
]  9 : 
StudentCourseRequest  ; O
request  P W
)  W X
{!! 	
return"" 
await"" 

BaseCreate"" #
(""# $
request""$ +
)""+ ,
;"", -
}## 	
['' 	
Route''	 
('' 
$str''  
)''  !
]''! "
[(( 	

HttpDelete((	 
](( 
[)) 	

Permission))	 
()) 
nameof)) 
()) 
StudentCourse)) (
)))( )
,))) *
Crud))+ /
.))/ 0
Delete))0 6
)))6 7
]))7 8
public** 
async** 
Task** 
<** 
IActionResult** '
>**' (
Delete**) /
(**/ 0
int**0 3
id**4 6
)**6 7
{++ 	
return,, 
await,, 

BaseDelete,, #
(,,# $
id,,$ &
),,& '
;,,' (
}-- 	
[// 	
Route//	 
(// 
$str//  
)//  !
]//! "
[00 	
HttpGet00	 
]00 
[11 	

Permission11	 
(11 
nameof11 
(11 
StudentCourse11 (
)11( )
,11) *
Crud11+ /
.11/ 0
Select110 6
)116 7
]117 8
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
GetById22) 0
(220 1
int221 4
id225 7
)227 8
{33 	
return44 
await44 
BaseGetById44 $
(44$ %
id44% '
)44' (
;44( )
}55 	
[77 	
Route77	 
(77 
$str77 1
)771 2
]772 3
[88 	
HttpGet88	 
]88 
[99 	

Permission99	 
(99 
nameof99 
(99 
StudentCourse99 (
)99( )
,99) *
Crud99+ /
.99/ 0
Select990 6
)996 7
]997 8
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
GetAllByStudentId::) :
(::: ;
int::; >
	studentId::? H
)::H I
{;; 	
var<< 
result<< 
=<< 
await<< 
Manager<< &
.<<& '"
GetAllByStudentIdAsync<<' =
(<<= >
	studentId<<> G
)<<G H
;<<H I
return== 
Ok== 
(== 
new== 
ApiResponse== %
(==% &
LocalizationService==& 9
,==9 :
Logger==; A
)==A B
.==B C
Ok==C E
(==E F
Mapper>> 
.>> 
Map>> 
<>> 
IList>>  
<>>  !
StudentCourse>>! .
>>>. /
,>>/ 0
IList>>1 6
<>>6 7!
StudentCourseResponse>>7 L
>>>L M
>>>M N
(>>N O
result>>O U
.>>U V

ResultList>>V `
)>>` a
,>>a b
result>>c i
.>>i j
Count>>j o
)>>o p
)>>p q
;>>q r
}?? 	
[@@ 	
Route@@	 
(@@ 
$str@@ /
)@@/ 0
]@@0 1
[AA 	
HttpGetAA	 
]AA 
[BB 	

PermissionBB	 
(BB 
nameofBB 
(BB 
StudentCourseBB (
)BB( )
,BB) *
CrudBB+ /
.BB/ 0
SelectBB0 6
)BB6 7
]BB7 8
publicCC 
asyncCC 
TaskCC 
<CC 
IActionResultCC '
>CC' (
GetAllByCourseIdCC) 9
(CC9 :
intCC: =
courseIdCC> F
)CCF G
{DD 	
varEE 
resultEE 
=EE 
awaitEE 
ManagerEE &
.EE& '!
GetAllByCourseIdAsyncEE' <
(EE< =
courseIdEE= E
)EEE F
;EEF G
returnFF 
OkFF 
(FF 
newFF 
ApiResponseFF %
(FF% &
LocalizationServiceFF& 9
,FF9 :
LoggerFF; A
)FFA B
.FFB C
OkFFC E
(FFE F
MapperGG 
.GG 
MapGG 
<GG 
IListGG  
<GG  !
StudentCourseGG! .
>GG. /
,GG/ 0
IListGG1 6
<GG6 7!
StudentCourseResponseGG7 L
>GGL M
>GGM N
(GGN O
resultGGO U
.GGU V

ResultListGGV `
)GG` a
,GGa b
resultGGc i
.GGi j
CountGGj o
)GGo p
)GGp q
;GGq r
}HH 	
}JJ 
}KK ê:
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Controllers\TeacherController.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Controllers' 2
{ 
[ 
Route 

(
 
ApiConstants 
. 
DefaultRoute $
+% &
nameof' -
(- .
Teacher. 5
)5 6
)6 7
]7 8
public 

class 
TeacherController "
:# $4
(BaseControllerWithAuthorizationAndUpdate% M
<M N
TeacherN U
,U V
TeacherRequestW e
,e f
TeacherRequestg u
,u v
TeacherResponse	w Ü
,
Ü á
ITeacherManager
à ó
,
ó ò
int
ô ú
>
ú ù
{ 
public 
TeacherController  
(  !
ITeacherManager! 0
teacherManager1 ?
,? @ 
ILocalizationServiceA U
localizationServiceV i
,i j
ILoggerk r
<r s
TeacherController	s Ñ
>
Ñ Ö
logger
Ü å
,
å ç
IMapper
é ï
mapper
ñ ú
)
ú ù
: 	
base
 
( 
teacherManager 
, 
localizationService 2
,2 3
logger4 :
,: ;
mapper< B
)B C
{ 	
} 	
[ 	
Route	 
( 
$str 
) 
] 
[ 	
HttpPost	 
] 
[   	

Permission  	 
(   
nameof   
(   
Teacher   "
)  " #
,  # $
Crud  % )
.  ) *
Create  * 0
)  0 1
]  1 2
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
Create!!) /
(!!/ 0
[!!0 1
FromBody!!1 9
]!!9 :
TeacherRequest!!; I
request!!J Q
)!!Q R
{"" 	
return## 
await## 

BaseCreate## #
(### $
request##$ +
)##+ ,
;##, -
}$$ 	
[&& 	
Route&&	 
(&& 
$str&&  
)&&  !
]&&! "
['' 	
HttpPut''	 
]'' 
[(( 	

Permission((	 
((( 
nameof(( 
((( 
Teacher(( "
)((" #
,((# $
Crud((% )
.(() *
Update((* 0
)((0 1
]((1 2
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
Update))) /
())/ 0
int))0 3
id))4 6
,))6 7
[))8 9
FromBody))9 A
]))A B
TeacherRequest))C Q
request))R Y
)))Y Z
{** 	
return++ 
await++ 

BaseUpdate++ #
(++# $
id++$ &
,++& '
request++( /
)++/ 0
;++0 1
},, 	
[// 	
Route//	 
(// 
$str//  
)//  !
]//! "
[00 	

HttpDelete00	 
]00 
[11 	

Permission11	 
(11 
nameof11 
(11 
Teacher11 "
)11" #
,11# $
Crud11% )
.11) *
Delete11* 0
)110 1
]111 2
public22 
async22 
Task22 
<22 
IActionResult22 '
>22' (
Delete22) /
(22/ 0
int220 3
id224 6
)226 7
{33 	
return44 
await44 

BaseDelete44 #
(44# $
id44$ &
)44& '
;44' (
}55 	
[77 	
Route77	 
(77 
$str77  
)77  !
]77! "
[88 	
HttpGet88	 
]88 
[99 	

Permission99	 
(99 
nameof99 
(99 
Teacher99 "
)99" #
,99# $
Crud99% )
.99) *
Select99* 0
)990 1
]991 2
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
GetById::) 0
(::0 1
int::1 4
id::5 7
)::7 8
{;; 	
return<< 
await<< 
BaseGetById<< $
(<<$ %
id<<% '
)<<' (
;<<( )
}== 	
[?? 	
Route??	 
(?? 
$str?? .
)??. /
]??/ 0
[@@ 	
HttpGet@@	 
]@@ 
[AA 	

PermissionAA	 
(AA 
nameofAA 
(AA 
TeacherAA "
)AA" #
,AA# $
CrudAA% )
.AA) *
SelectAA* 0
)AA0 1
]AA1 2
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
GetByTeacherNoBB) 7
(BB7 8
intBB8 ;
	teacherNoBB< E
)BBE F
{CC 	
varDD 
resultDD 
=DD 
awaitDD 
ManagerDD &
.DD& '
GetByTeacherNoAsyncDD' :
(DD: ;
	teacherNoDD; D
)DDD E
;DDE F
returnEE 
OkEE 
(EE 
newEE 
ApiResponseEE %
(EE% &
LocalizationServiceEE& 9
,EE9 :
LoggerEE; A
)EEA B
.EEB C
OkEEC E
(EEE F
MapperEEF L
.EEL M
MapEEM P
<EEP Q
TeacherEEQ X
,EEX Y
TeacherResponseEEZ i
>EEi j
(EEj k
resultEEk q
)EEq r
)EEr s
)EEs t
;EEt u
}FF 	
[GG 	
RouteGG	 
(GG 
$strGG 
)GG 
]GG 
[HH 	
HttpGetHH	 
]HH 
[II 	

PermissionII	 
(II 
nameofII 
(II 
TeacherII "
)II" #
,II# $
CrudII% )
.II) *
SelectII* 0
)II0 1
]II1 2
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
IActionResultJJ '
>JJ' (
GetAllJJ) /
(JJ/ 0
)JJ0 1
{KK 	
varLL 
resultLL 
=LL 
awaitLL 
ManagerLL &
.LL& '
GetAllAsyncLL' 2
(LL2 3
)LL3 4
;LL4 5
returnMM 
OkMM 
(MM 
newMM 
ApiResponseMM %
(MM% &
LocalizationServiceMM& 9
,MM9 :
LoggerMM; A
)MMA B
.MMB C
OkMMC E
(MME F
MapperNN 
.NN 
MapNN 
<NN 
IEnumerableNN &
<NN& '
TeacherNN' .
>NN. /
,NN/ 0
IEnumerableNN1 <
<NN< =
TeacherResponseNN= L
>NNL M
>NNM N
(NNN O
resultNNO U
.NNU V

ResultListNNV `
)NN` a
,NNa b
resultNNc i
.NNi j
CountNNj o
)NNo p
)NNp q
;NNq r
}OO 	
}QQ 
}RR ø%
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\ApplicationContext.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
{ 
public 

class 
ApplicationContext #
:$ % 
AuthorizationContext& :
{ 
public 
ApplicationContext !
(! "
DbContextOptions" 2
options3 :
): ;
: 
base 
( 
options 
) 
{ 	
} 	
public 
virtual 
DbSet 
< 
Student $
>$ %
Students& .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
virtual 
DbSet 
< 
Course #
># $
Courses% ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
virtual 
DbSet 
< 
Teacher $
>$ %
Teachers& .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
public 
virtual 
DbSet 
< 
StudentCourse *
>* +
StudentCourses, :
{; <
get= @
;@ A
setB E
;E F
}G H
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
modelBuilder"" 
."" 
ApplyConfiguration"" +
(""+ ,
new"", /%
StudentModelConfiguration""0 I
<""I J
Student""J Q
>""Q R
(""R S
)""S T
)""T U
;""U V
modelBuilder## 
.## 
ApplyConfiguration## +
(##+ ,
new##, /$
CourseModelConfiguration##0 H
<##H I
Course##I O
>##O P
(##P Q
)##Q R
)##R S
;##S T
modelBuilder$$ 
.$$ 
ApplyConfiguration$$ +
($$+ ,
new$$, /%
TeacherModelConfiguration$$0 I
<$$I J
Teacher$$J Q
>$$Q R
($$R S
)$$S T
)$$T U
;$$U V
modelBuilder%% 
.%% 
ApplyConfiguration%% +
(%%+ ,
new%%, /+
StudentCourseModelConfiguration%%0 O
<%%O P
StudentCourse%%P ]
>%%] ^
(%%^ _
)%%_ `
)%%` a
;%%a b
Startup)) 
.)) !
SeedAuthorizationData)) )
.))) *%
SeedClientApplicationData))* C
())C D
modelBuilder))D P
)))P Q
;))Q R
Startup++ 
.++ !
SeedAuthorizationData++ )
.++) *
SeedUserData++* 6
(++6 7
modelBuilder++7 C
)++C D
;++D E
Startup-- 
.-- !
SeedAuthorizationData-- )
.--) *
SeedRoleData--* 6
(--6 7
modelBuilder--7 C
)--C D
;--D E
Startup// 
.// !
SeedAuthorizationData// )
.//) *
SeedRoleEntityData//* <
(//< =
modelBuilder//= I
)//I J
;//J K
var22 

cascadeFKs22 
=22 
modelBuilder22 )
.22) *
Model22* /
.22/ 0
GetEntityTypes220 >
(22> ?
)22? @
.33 

SelectMany33 
(33 
t33 
=>33  
t33! "
.33" #
GetForeignKeys33# 1
(331 2
)332 3
)333 4
.44 
Where44 
(44 
fk44 
=>44 
!44 
fk44  
.44  !
IsOwnership44! ,
&&44- /
fk440 2
.442 3
DeleteBehavior443 A
==44B D
DeleteBehavior44E S
.44S T
Cascade44T [
)44[ \
;44\ ]
foreach66 
(66 
var66 
fk66 
in66 

cascadeFKs66 )
)66) *
fk77 
.77 
DeleteBehavior77 !
=77" #
DeleteBehavior77$ 2
.772 3
Restrict773 ;
;77; <
modelBuilder99 
.99 
SetModelToSnakeCase99 ,
(99, -
)99- .
;99. /
}:: 	
};; 
}<< Ë
fC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\IUnitOfWorkWebApi.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
{ 
public 

	interface 
IUnitOfWorkWebApi &
:' (
IUnitOfWork) 4
{ 
IStudentRepository		 
Students		 #
{		$ %
get		& )
;		) *
}		+ ,
ICourseRepository

 
Courses

 !
{

" #
get

$ '
;

' (
}

) *
ITeacherRepository 
Teachers #
{$ %
get& )
;) *
}+ ,$
IStudentCourseRepository  
StudentCourses! /
{0 1
get2 5
;5 6
}7 8
} 
} †
ÄC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\ModelConfiguration\CourseModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
ModelConfiguration, >
{ 
public 

class $
CourseModelConfiguration )
<) *
T* +
>+ ,
:- ."
BaseModelConfiguration/ E
<E F
TF G
,G H
intI L
>L M
whereN S
TT U
:V W
CourseX ^
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
CourseNo$ ,
), -
.- .

IsRequired. 8
(8 9
)9 :
;: ;
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Name$ (
)( )
.) *

IsRequired* 4
(4 5
)5 6
.6 7
HasMaxLength7 C
(C D
$numD F
)F G
;G H
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	TeacherId$ -
)- .
.. /

IsRequired/ 9
(9 :
): ;
;; <
builder 
. 
HasOne 
( 
r 
=> 
r  !
.! "
Teacher" )
)) *
.* +
WithMany+ 3
(3 4
c4 5
=>6 8
(9 :
IEnumerable: E
<E F
TF G
>G H
)H I
cI J
.J K
CoursesK R
)R S
.S T
HasForeignKeyT a
(a b
rb c
=>d f
rg h
.h i
	TeacherIdi r
)r s
.s t
HasPrincipalKey	t É
(
É Ñ
c
Ñ Ö
=>
Ü à
c
â ä
.
ä ã
Id
ã ç
)
ç é
.
é è

IsRequired
è ô
(
ô ö
)
ö õ
;
õ ú
builder 
. 
HasIndex 
( 
p 
=> !
p" #
.# $
CourseNo$ ,
), -
.- .
IsUnique. 6
(6 7
)7 8
;8 9
} 	
} 
} ±
áC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\ModelConfiguration\StudentCourseModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
ModelConfiguration, >
{ 
public 

class +
StudentCourseModelConfiguration 0
<0 1
T1 2
>2 3
:4 5"
BaseModelConfiguration6 L
<L M
TM N
,N O
intP S
>S T
whereU Z
T[ \
:] ^
StudentCourse_ l
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	StudentId$ -
)- .
.. /

IsRequired/ 9
(9 :
): ;
;; <
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
CourseId$ ,
), -
.- .

IsRequired. 8
(8 9
)9 :
;: ;
builder 
. 
HasOne 
( 
r 
=> 
r  !
.! "
Student" )
)) *
.* +
WithMany+ 3
(3 4
c4 5
=>6 8
(9 :
IEnumerable: E
<E F
TF G
>G H
)H I
cI J
.J K
StudentCoursesK Y
)Y Z
.Z [
HasForeignKey[ h
(h i
ri j
=>k m
rn o
.o p
	StudentIdp y
)y z
.z {
HasPrincipalKey	{ ä
(
ä ã
c
ã å
=>
ç è
c
ê ë
.
ë í
Id
í î
)
î ï
.
ï ñ

IsRequired
ñ †
(
† °
)
° ¢
;
¢ £
builder 
. 
HasOne 
( 
r 
=> 
r  !
.! "
Course" (
)( )
.) *
WithMany* 2
(2 3
c3 4
=>5 7
(8 9
IEnumerable9 D
<D E
TE F
>F G
)G H
cH I
.I J
StudentCoursesJ X
)X Y
.Y Z
HasForeignKeyZ g
(g h
rh i
=>j l
rm n
.n o
CourseIdo w
)w x
.x y
HasPrincipalKey	y à
(
à â
c
â ä
=>
ã ç
c
é è
.
è ê
Id
ê í
)
í ì
.
ì î

IsRequired
î û
(
û ü
)
ü †
;
† °
} 	
} 
} ª
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\ModelConfiguration\StudentModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
ModelConfiguration, >
{ 
public 

class %
StudentModelConfiguration *
<* +
T+ ,
>, -
:. /"
BaseModelConfiguration0 F
<F G
TG H
,H I
intJ M
>M N
whereO T
TU V
:W X
StudentY `
{ 
public		 
override		 
void		 
	Configure		 &
(		& '
EntityTypeBuilder		' 8
<		8 9
T		9 :
>		: ;
builder		< C
)		C D
{

 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	StudentNo$ -
)- .
.. /

IsRequired/ 9
(9 :
): ;
;; <
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Name$ (
)( )
.) *

IsRequired* 4
(4 5
)5 6
.6 7
HasMaxLength7 C
(C D
$numD F
)F G
;G H
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Surname$ +
)+ ,
., -

IsRequired- 7
(7 8
)8 9
.9 :
HasMaxLength: F
(F G
$numG I
)I J
;J K
builder 
. 
HasIndex 
( 
p 
=> !
p" #
.# $
	StudentNo$ -
)- .
.. /
IsUnique/ 7
(7 8
)8 9
;9 :
} 	
} 
} ª
ÅC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\ModelConfiguration\TeacherModelConfiguration.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
ModelConfiguration, >
{ 
public 

class %
TeacherModelConfiguration *
<* +
T+ ,
>, -
:. /"
BaseModelConfiguration0 F
<F G
TG H
,H I
intJ M
>M N
whereO T
TU V
:W X
TeacherY `
{		 
public

 
override

 
void

 
	Configure

 &
(

& '
EntityTypeBuilder

' 8
<

8 9
T

9 :
>

: ;
builder

< C
)

C D
{ 	
base 
. 
	Configure 
( 
builder "
)" #
;# $
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
	TeacherNo$ -
)- .
.. /

IsRequired/ 9
(9 :
): ;
;; <
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Name$ (
)( )
.) *

IsRequired* 4
(4 5
)5 6
.6 7
HasMaxLength7 C
(C D
$numD F
)F G
;G H
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
Surname$ +
)+ ,
., -

IsRequired- 7
(7 8
)8 9
.9 :
HasMaxLength: F
(F G
$numG I
)I J
;J K
builder 
. 
HasIndex 
( 
p 
=> !
p" #
.# $
	TeacherNo$ -
)- .
.. /
IsUnique/ 7
(7 8
)8 9
;9 :
} 	
} 
} ã
rC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\CourseRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{		 
public

 

class

 
CourseRepository

 !
:

" #
BaseRepository

$ 2
<

2 3
Course

3 9
,

9 :
int

; >
>

> ?
,

? @
ICourseRepository

A R
{ 
public 
CourseRepository 
(  
	DbContext  )
	dbContext* 3
)3 4
:5 6
base7 ;
(; <
	dbContext< E
)E F
{ 	
} 	
public 
async 
Task 
< 
Course  
>  !
GetByCourseNoAsync" 4
(4 5
int5 8
courseNo9 A
)A B
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
CourseNo$ ,
==- /
courseNo0 8
)8 9
.9 :
IncludeMultiple: I
(I J
pJ K
=>L N
pO P
.P Q
TeacherQ X
,X Y
pZ [
=>\ ^
p_ `
.` a
StudentCoursesa o
)o p
.p q 
FirstOrDefaultAsync	q Ñ
(
Ñ Ö
)
Ö Ü
;
Ü á
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Course& ,
>, -
>- ."
GetAllByTeacherIdAsync/ E
(E F
intF I
	teacherIdJ S
)S T
{ 	
return 
await 
GetAll 
(  
	predicate  )
:) *
p+ ,
=>- /
p0 1
.1 2
	TeacherId2 ;
==< >
	teacherId? H
)H I
.I J
IncludeMultipleJ Y
(Y Z
pZ [
=>\ ^
p_ `
.` a
Teachera h
,h i
pj k
=>l n
po p
.p q
StudentCoursesq 
)	 Ä
.
Ä Å
ToCustomList
Å ç
(
ç é
)
é è
;
è ê
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Course& ,
>, -
>- .
GetAllAsync/ :
(: ;
); <
{ 	
return 
await 
GetAll 
(  
)  !
.! "
IncludeMultiple" 1
(1 2
p2 3
=>4 6
p7 8
.8 9
Teacher9 @
,@ A
pB C
=>D F
pG H
.H I
StudentCoursesI W
)W X
.X Y
ToCustomListY e
(e f
)f g
;g h
} 	
} 
} É	
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\ICourseRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{ 
public 

	interface 
ICourseRepository &
:' (
IRepository) 4
<4 5
Course5 ;
,; <
int= @
>@ A
{		 
Task

 
<

 
Course

 
>

 
GetByCourseNoAsync

 '
(

' (
int

( +
courseNo

, 4
)

4 5
;

5 6
Task 
< 
ICustomList 
< 
Course 
>  
>  !"
GetAllByTeacherIdAsync" 8
(8 9
int9 <
	teacherId= F
)F G
;G H
Task 
< 
ICustomList 
< 
Course 
>  
>  !
GetAllAsync" -
(- .
). /
;/ 0
} 
} ü
zC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\IStudentCourseRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{ 
public 

	interface $
IStudentCourseRepository -
:. /
IRepository0 ;
<; <
StudentCourse< I
,I J
intK N
>N O
{		 
Task

 
<

 
ICustomList

 
<

 
StudentCourse

 &
>

& '
>

' ("
GetAllByStudentIdAsync

) ?
(

? @
int

@ C
	studentId

D M
)

M N
;

N O
Task 
< 
ICustomList 
< 
StudentCourse &
>& '
>' (!
GetAllByCourseIdAsync) >
(> ?
int? B
courseIdC K
)K L
;L M
} 
} ∂	
tC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\IStudentRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{ 
public 

	interface 
IStudentRepository '
:( )
IRepository* 5
<5 6
Student6 =
,= >
int? B
>B C
{		 
Task

 
<

 
Student

 
>

 
GetByStudentNoAsync

 )
(

) *
int

* -
	studentNo

. 7
)

7 8
;

8 9
Task 
< 
ICustomList 
< 
Student  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
Task 
< 
ICustomList 
< 
Student  
>  !
>! "
GetAllAsync# .
(. /
int/ 2
	pageIndex3 <
,< =
int> A
pageSizeB J
)J K
;K L
} 
} ñ
tC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\ITeacherRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{ 
public 

	interface 
ITeacherRepository '
:( )
IRepository* 5
<5 6
Teacher6 =
,= >
int? B
>B C
{		 
Task

 
<

 
Teacher

 
>

 
GetByTeacherNoAsync

 )
(

) *
int

* -
	teacherNo

. 7
)

7 8
;

8 9
Task 
< 
ICustomList 
< 
Teacher  
>  !
>! "
GetAllAsync# .
(. /
)/ 0
;0 1
} 
} ⁄
yC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\StudentCourseRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{		 
public

 

class

 #
StudentCourseRepository

 (
:

) *
BaseRepository

+ 9
<

9 :
StudentCourse

: G
,

G H
int

I L
>

L M
,

M N$
IStudentCourseRepository

O g
{ 
public #
StudentCourseRepository &
(& '
	DbContext' 0
	dbContext1 :
): ;
:< =
base> B
(B C
	dbContextC L
)L M
{ 	
} 	
public 
async 
Task 
< 
ICustomList %
<% &
StudentCourse& 3
>3 4
>4 5"
GetAllByStudentIdAsync6 L
(L M
intM P
	studentIdQ Z
)Z [
{ 	
return 
await 
GetAll 
(  
	predicate  )
:) *
p+ ,
=>- /
p0 1
.1 2
	StudentId2 ;
==< >
	studentId? H
)H I
.I J
IncludeMultipleJ Y
(Y Z
pZ [
=>\ ^
p_ `
.` a
Studenta h
,h i
pj k
=>l n
po p
.p q
Courseq w
)w x
.x y
ToCustomList	y Ö
(
Ö Ü
)
Ü á
;
á à
} 	
public 
async 
Task 
< 
ICustomList %
<% &
StudentCourse& 3
>3 4
>4 5!
GetAllByCourseIdAsync6 K
(K L
intL O
courseIdP X
)X Y
{ 	
return 
await 
GetAll 
(  
	predicate  )
:) *
p+ ,
=>- /
p0 1
.1 2
CourseId2 :
==; =
courseId> F
)F G
.G H
IncludeMultipleH W
(W X
pX Y
=>Z \
p] ^
.^ _
Student_ f
,f g
ph i
=>j l
pm n
.n o
Courseo u
)u v
.v w
ToCustomList	w É
(
É Ñ
)
Ñ Ö
;
Ö Ü
} 	
} 
} €
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\StudentRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{		 
public

 

class

 
StudentRepository

 "
:

# $
BaseRepository

% 3
<

3 4
Student

4 ;
,

; <
int

= @
>

@ A
,

A B
IStudentRepository

C U
{ 
public 
StudentRepository  
(  !
	DbContext! *
	dbContext+ 4
)4 5
:6 7
base8 <
(< =
	dbContext= F
)F G
{ 	
} 	
public 
async 
Task 
< 
Student !
>! "
GetByStudentNoAsync# 6
(6 7
int7 :
	studentNo; D
)D E
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
	StudentNo$ -
==. 0
	studentNo1 :
): ;
.; <
IncludeMultiple< K
(K L
pL M
=>N P
pQ R
.R S
StudentCoursesS a
)a b
.b c
FirstOrDefaultAsyncc v
(v w
)w x
;x y
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Student& -
>- .
>. /
GetAllAsync0 ;
(; <
)< =
{ 	
return 
await 
GetAll 
(  
)  !
.! "
IncludeMultiple" 1
(1 2
p2 3
=>4 6
p7 8
.8 9
StudentCourses9 G
)G H
.H I
ToCustomListI U
(U V
)V W
;W X
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Student& -
>- .
>. /
GetAllAsync0 ;
(; <
int< ?
	pageIndex@ I
,I J
intK N
pageSizeO W
)W X
{ 	
return 
await 
( 
await !
GetAllWithPagingAsync  5
(5 6
paging6 <
:< =
new> A
PagingB H
(H I
	pageIndexI R
,R S
pageSizeT \
)\ ]
)] ^
)^ _
._ `
IncludeMultiple` o
(o p
pp q
=>r t
pu v
.v w
StudentCourses	w Ö
)
Ö Ü
.
Ü á
ToCustomList
á ì
(
ì î
)
î ï
;
ï ñ
} 	
} 
} ∂
sC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Repositories\TeacherRepository.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Repositories, 8
{		 
public

 

class

 
TeacherRepository

 "
:

# $
BaseRepository

% 3
<

3 4
Teacher

4 ;
,

; <
int

= @
>

@ A
,

A B
ITeacherRepository

C U
{ 
public 
TeacherRepository  
(  !
	DbContext! *
	dbContext+ 4
)4 5
:6 7
base8 <
(< =
	dbContext= F
)F G
{ 	
} 	
public 
async 
Task 
< 
Teacher !
>! "
GetByTeacherNoAsync# 6
(6 7
int7 :
	teacherNo; D
)D E
{ 	
return 
await 
Get 
( 
p 
=> !
p" #
.# $
	TeacherNo$ -
==. 0
	teacherNo1 :
): ;
.; <
IncludeMultiple< K
(K L
pL M
=>N P
pQ R
.R S
CoursesS Z
)Z [
.[ \
FirstOrDefaultAsync\ o
(o p
)p q
;q r
} 	
public 
async 
Task 
< 
ICustomList %
<% &
Teacher& -
>- .
>. /
GetAllAsync0 ;
(; <
)< =
{ 	
return 
await 
GetAll 
(  
)  !
.! "
IncludeMultiple" 1
(1 2
p2 3
=>4 6
p7 8
.8 9
Courses9 @
)@ A
.A B
ToCustomListB N
(N O
)O P
;P Q
} 	
} 
} ì
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\Seeding\SeedWebApiData.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
.+ ,
Seeding, 3
{ 
public		 

class		 
SeedWebApiData		 
{

 
public 
SeedWebApiData 
( 
) 
{ 	
} 	
public 
void 
SeedAll 
( 
ModelBuilder (
modelBuilder) 5
)5 6
{ 	
throw 
new !
NotSupportedException +
(+ ,
), -
;- .
} 	
} 
} ˙
eC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Data\UnitOfWorkWebApi.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Data' +
{ 
public 

class 
UnitOfWorkWebApi !
:" #

UnitOfWork$ .
<. /
ApplicationContext/ A
>A B
,B C
IUnitOfWorkWebApiD U
{ 
public 
UnitOfWorkWebApi 
(  
ApplicationContext  2
context3 :
): ;
:< =
base> B
(B C
contextC J
)J K
{		 	
Students 
= 
new 
StudentRepository ,
(, -
context- 4
)4 5
;5 6
Courses 
= 
new 
CourseRepository *
(* +
context+ 2
)2 3
;3 4
Teachers 
= 
new 
TeacherRepository ,
(, -
context- 4
)4 5
;5 6
StudentCourses 
= 
new  #
StudentCourseRepository! 8
(8 9
context9 @
)@ A
;A B
} 	
public 
IStudentRepository !
Students" *
{+ ,
get- 0
;0 1
}2 3
public 
ICourseRepository  
Courses! (
{) *
get+ .
;. /
}0 1
public 
ITeacherRepository !
Teachers" *
{+ ,
get- 0
;0 1
}2 3
public $
IStudentCourseRepository '
StudentCourses( 6
{7 8
get9 <
;< =
}> ?
} 
} ñ

]C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Models\Course.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Models' -
{ 
public 

class 
Course 
: 
	BaseModel #
<# $
int$ '
>' (
{ 
public 
int 
CourseNo 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
int

 
	TeacherId

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
virtual 
Teacher 
Teacher &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
virtual 
ICollection "
<" #
StudentCourse# 0
>0 1
StudentCourses2 @
{A B
getC F
;F G
setH K
;K L
}M N
} 
} È
^C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Models\Student.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Models' -
{ 
public 

class 
Student 
: 
	BaseModel $
<$ %
int% (
>( )
{ 
public 
int 
	StudentNo 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
Surname

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
virtual 
ICollection "
<" #
StudentCourse# 0
>0 1
StudentCourses2 @
{A B
getC F
;F G
setH K
;K L
}M N
} 
} ∆
dC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Models\StudentCourse.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Models' -
{ 
public 

class 
StudentCourse 
:  
	BaseModel! *
<* +
int+ .
>. /
{ 
public 
int 
	StudentId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CourseId 
{ 
get !
;! "
set# &
;& '
}( )
public

 
virtual

 
Student

 
Student

 &
{

' (
get

) ,
;

, -
set

. 1
;

1 2
}

3 4
public 
virtual 
Course 
Course $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} €
^C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Models\Teacher.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Models' -
{ 
public 

class 
Teacher 
: 
	BaseModel $
<$ %
int% (
>( )
{ 
public 
int 
	TeacherNo 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
Surname

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
virtual 
ICollection "
<" #
Course# )
>) *
Courses+ 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} –
WC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Program.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
{ 
public 

static 
class 
Program 
{ 
public		 
static		 
void		 
Main		 
(		  
string		  &
[		& '
]		' (
args		) -
)		- .
{

 	 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
=>J L
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. 
ConfigureLogging !
(! "
(" #
logging# *
)* +
=>, .
{ 
logging 
.  
AddDebug  (
(( )
)) *
;* +
} 
) 
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 
} Â
fC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Requests\CourseRequest.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Requests' /
{ 
public 

class 
CourseRequest 
{ 
public 
int 
CourseNo 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
	TeacherId 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
virtual		 
TeacherRequest		 %
Teacher		& -
{		. /
get		0 3
;		3 4
set		5 8
;		8 9
}		: ;
} 
} ë
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Requests\StudentCourseRequest.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Requests' /
{ 
public 

class  
StudentCourseRequest %
{ 
public 
int 
	StudentId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CourseId 
{ 
get !
;! "
set# &
;& '
}( )
public 
virtual 
StudentRequest %
Student& -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public		 
virtual		 
CourseRequest		 $
Course		% +
{		, -
get		. 1
;		1 2
set		3 6
;		6 7
}		8 9
} 
} ±
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Requests\StudentRequest.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Requests' /
{ 
public 

class 
StudentRequest 
{ 
public 
int 
	StudentNo 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
}

 
} ±
gC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Requests\TeacherRequest.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
Requests' /
{ 
public 

class 
TeacherRequest 
{ 
public 
int 
	TeacherNo 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
} 
}		 ˙
mC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Resources\LocalizationService.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Resources' 0
{ 
public 

class 
LocalizationService $
:% & 
ILocalizationService' ;
{ 
private		 
readonly		 
IStringLocalizer		 )

_localizer		* 4
;		4 5
public 
LocalizationService "
(" ##
IStringLocalizerFactory# :
factory; B
)B C
{ 	
var 
type 
= 
typeof 
( 
SharedResources -
)- .
;. /
var 
assemblyName 
= 
new "
AssemblyName# /
(/ 0
type0 4
.4 5
GetTypeInfo5 @
(@ A
)A B
.B C
AssemblyC K
.K L
FullNameL T
)T U
;U V

_localizer 
= 
factory  
.  !
Create! '
(' (
$str( 9
,9 :
assemblyName; G
.G H
NameH L
)L M
;M N
} 	
public 
LocalizedString 
GetValue '
(' (
string( .
key/ 2
)2 3
{ 	
return 

_localizer 
[ 
key !
]! "
;" #
} 	
} 
} ˝
hC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Responses\CourseResponse.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Responses' 0
{ 
public 

class 
CourseResponse 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
CourseNo 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
	TeacherId 
{ 
get "
;" #
set$ '
;' (
}) *
public

 
virtual

 
TeacherResponse

 &
Teacher

' .
{

/ 0
get

1 4
;

4 5
set

6 9
;

9 :
}

; <
} 
} ™	
oC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Responses\StudentCourseResponse.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Responses' 0
{ 
public 

class !
StudentCourseResponse &
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
	StudentId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
CourseId 
{ 
get !
;! "
set# &
;& '
}( )
public		 
virtual		 
StudentResponse		 &
Student		' .
{		/ 0
get		1 4
;		4 5
set		6 9
;		9 :
}		; <
public

 
virtual

 
CourseResponse

 %
Course

& ,
{

- .
get

/ 2
;

2 3
set

4 7
;

7 8
}

9 :
} 
} »
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Responses\StudentResponse.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Responses' 0
{ 
public 

class 
StudentResponse  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
	StudentNo 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} »
iC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Responses\TeacherResponse.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '
	Responses' 0
{ 
public 

class 
TeacherResponse  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
	TeacherNo 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 ∏
_C:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\SharedResources.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
{ 
public 

class 
SharedResources  
{ 
} 
} ÿw
WC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Startup.cs
	namespace&& 	
CustomFramework&&
 
.&& 
SampleWebApi&& &
{'' 
public(( 

class(( 
Startup(( 
{)) 
public** 
static** 
AppSettings** !
AppSettings**" -
{**. /
get**0 3
;**3 4
private**5 <
set**= @
;**@ A
}**B C
public++ 
static++ !
SeedAuthorizationData++ +!
SeedAuthorizationData++, A
{++B C
get++D G
;++G H
private++I P
set++Q T
;++T U
}++V W
public,, 
static,, 
SeedWebApiData,, $
SeedWebApiData,,% 3
{,,4 5
get,,6 9
;,,9 :
private,,; B
set,,C F
;,,F G
},,H I
public-- 
static-- 
string-- 
ConnectionString-- -
{--. /
get--0 3
;--3 4
private--5 <
set--= @
;--@ A
}--B C
public// 
Startup// 
(// 
IHostingEnvironment// *
env//+ .
)//. /
{00 	
var11 
builder11 
=11 
new11  
ConfigurationBuilder11 2
(112 3
)113 4
.22 
SetBasePath22 
(22 
	Directory22 &
.22& '
GetCurrentDirectory22' :
(22: ;
)22; <
)22< =
.33 
AddJsonFile33 
(33 
$str33 /
)33/ 0
.44 
AddJsonFile44 
(44 
$"44 
appsettings.44 +
{44+ ,
env44, /
.44/ 0
EnvironmentName440 ?
}44? @
.json44@ E
"44E F
,44F G
optional44H P
:44P Q
true44R V
)44V W
.55 
AddUserSecrets55 
<55  
Startup55  '
>55' (
(55( )
)55) *
;55* +
if77 
(77 
env77 
.77 
IsDevelopment77 !
(77! "
)77" #
)77# $
{88 
builder99 
.99 
AddUserSecrets99 &
<99& '
Startup99' .
>99. /
(99/ 0
)990 1
;991 2
}:: 
builder<< 
.<< #
AddEnvironmentVariables<< +
(<<+ ,
)<<, -
;<<- .
Configuration== 
=== 
builder== #
.==# $
Build==$ )
(==) *
)==* +
;==+ ,
ConnectionString>> 
=>> 
Configuration>> ,
.>>, -
GetValue>>- 5
<>>5 6
string>>6 <
>>>< =
(>>= >
$str>>> d
)>>d e
;>>e f
AppSettings@@ 
=@@ 
new@@ 
AppSettings@@ )
(@@) *
)@@* +
;@@+ ,
ConfigurationAA 
.AA 

GetSectionAA $
(AA$ %
$strAA% 2
)AA2 3
.AA3 4
BindAA4 8
(AA8 9
AppSettingsAA9 D
)AAD E
;AAE F!
SeedAuthorizationDataCC !
=CC" #
newCC$ '!
SeedAuthorizationDataCC( =
(CC= >
)CC> ?
;CC? @
ConfigurationDD 
.DD 

GetSectionDD $
(DD$ %
$strDD% ?
)DD? @
.DD@ A
BindDDA E
(DDE F!
SeedAuthorizationDataDDF [
)DD[ \
;DD\ ]
SeedWebApiDataFF 
=FF 
newFF  
SeedWebApiDataFF! /
(FF/ 0
)FF0 1
;FF1 2
}GG 	
publicII 
IConfigurationII 
ConfigurationII +
{II, -
getII. 1
;II1 2
}II3 4
publicLL 
voidLL 
ConfigureServicesLL %
(LL% &
IServiceCollectionLL& 8
servicesLL9 A
)LLA B
{MM 	
servicesNN 
.NN 
AddSqlServerNN !
<NN! "
ApplicationContextNN" 4
>NN4 5
(NN5 6
ConnectionStringNN6 F
)NNF G
;NNG H
servicesPP 
.PP  
AddJwtAuthenticationPP )
(PP) *
AppSettingsPP* 5
.PP5 6
TokenPP6 ;
.PP; <
AudiencePP< D
,PPD E
AppSettingsPPF Q
.PPQ R
TokenPPR W
.PPW X
IssuerPPX ^
,PP^ _
AppSettingsPP` k
.PPk l
TokenPPl q
.PPq r
KeyPPr u
)PPu v
;PPv w
servicesRR 
.RR "
AddCustomAuthorizationRR +
(RR+ ,
newRR, /
ListRR0 4
<RR4 5%
CustomAuthorizationPolicyRR5 N
>RRN O
{SS 
newTT %
CustomAuthorizationPolicyTT -
{UU 
NameVV 
=VV 
$strVV '
,VV' (%
AuthorizationRequirementsWW -
=WW. /
newWW0 3
ListWW4 8
<WW8 9%
IAuthorizationRequirementWW9 R
>WWR S
{XX 
newYY .
"PermissionAuthorizationRequirementYY >
(YY> ?
)YY? @
,YY@ A
}ZZ 
}[[ 
}\\ 
)\\ 
;\\ 
services^^ 
.^^ #
AddSwaggerDocumentation^^ ,
(^^, -
)^^- .
;^^. /
services`` 
.`` !
AddWebApiUtilServices`` *
(``* +
)``+ ,
;``, -
servicesbb 
.bb 
AddAutoMapperbb "
(bb" #
)bb# $
;bb$ %
servicescc 
.cc "
AddAuthorizationModelscc +
(cc+ ,
)cc, -
;cc- .
servicesee 
.ee 
AddTransientee !
<ee! " 
ILocalizationServiceee" 6
,ee6 7
LocalizationServiceee8 K
>eeK L
(eeL M
)eeM N
;eeN O
vargg 
cultureInfosgg 
=gg 
newgg "
Listgg# '
<gg' (
CultureInfogg( 3
>gg3 4
{hh 
newii 
CultureInfoii 
(ii  
$strii  '
)ii' (
,ii( )
newjj 
CultureInfojj 
(jj  
$strjj  '
)jj' (
,jj( )
}kk 
;kk 
servicesmm 
.mm 
AddLocalizationmm $
(mm$ %
optionsmm% ,
=>mm- /
{mm0 1
optionsmm2 9
.mm9 :
ResourcesPathmm: G
=mmH I
$strmmJ U
;mmU V
}mmW X
)mmX Y
;mmY Z
servicesoo 
.oo 
	Configureoo 
<oo &
RequestLocalizationOptionsoo 9
>oo9 :
(oo: ;
optionsoo; B
=>ooC E
{pp 
optionsqq 
.qq !
DefaultRequestCultureqq -
=qq. /
newqq0 3
RequestCultureqq4 B
(qqB C
cultureqqC J
:qqJ K
$strqqL S
,qqS T
	uiCultureqqU ^
:qq^ _
$strqq` g
)qqg h
;qqh i
optionsrr 
.rr 
SupportedCulturesrr )
=rr* +
cultureInfosrr, 8
;rr8 9
optionsss 
.ss 
SupportedUICulturesss +
=ss, -
cultureInfosss. :
;ss: ;
optionstt 
.tt #
RequestCultureProviderstt /
.tt/ 0
Inserttt0 6
(tt6 7
$numtt7 8
,tt8 9
newtt: =6
*AcceptLanguageHeaderRequestCultureProvidertt> h
(tth i
)tti j
)ttj k
;ttk l
}uu 
)uu 
;uu 
servicesxx 
.xx 
AddTransientxx !
<xx! "
IUnitOfWorkWebApixx" 3
,xx3 4
UnitOfWorkWebApixx5 E
>xxE F
(xxF G
)xxG H
;xxH I
servicesyy 
.yy 
	AddScopedyy 
<yy 
	DbContextyy (
,yy( )
ApplicationContextyy* <
>yy< =
(yy= >
)yy> ?
;yy? @
serviceszz 
.zz 
	AddScopedzz 
<zz  
AuthorizationContextzz 3
,zz3 4
ApplicationContextzz5 G
>zzG H
(zzH I
)zzI J
;zzJ K
services}} 
.}} 
AddTransient}} !
<}}! "
IStudentRepository}}" 4
,}}4 5
StudentRepository}}6 G
>}}G H
(}}H I
)}}I J
;}}J K
services~~ 
.~~ 
AddTransient~~ !
<~~! "
ICourseRepository~~" 3
,~~3 4
CourseRepository~~5 E
>~~E F
(~~F G
)~~G H
;~~H I
services 
. 
AddTransient !
<! "
ITeacherRepository" 4
,4 5
TeacherRepository6 G
>G H
(H I
)I J
;J K
services
ÄÄ 
.
ÄÄ 
AddTransient
ÄÄ !
<
ÄÄ! "&
IStudentCourseRepository
ÄÄ" :
,
ÄÄ: ;%
StudentCourseRepository
ÄÄ< S
>
ÄÄS T
(
ÄÄT U
)
ÄÄU V
;
ÄÄV W
services
ÑÑ 
.
ÑÑ 
AddTransient
ÑÑ !
<
ÑÑ! "
IStudentManager
ÑÑ" 1
,
ÑÑ1 2
StudentManager
ÑÑ3 A
>
ÑÑA B
(
ÑÑB C
)
ÑÑC D
;
ÑÑD E
services
ÖÖ 
.
ÖÖ 
AddTransient
ÖÖ !
<
ÖÖ! "
ICourseManager
ÖÖ" 0
,
ÖÖ0 1
CourseManager
ÖÖ2 ?
>
ÖÖ? @
(
ÖÖ@ A
)
ÖÖA B
;
ÖÖB C
services
ÜÜ 
.
ÜÜ 
AddTransient
ÜÜ !
<
ÜÜ! "
ITeacherManager
ÜÜ" 1
,
ÜÜ1 2
TeacherManager
ÜÜ3 A
>
ÜÜA B
(
ÜÜB C
)
ÜÜC D
;
ÜÜD E
services
áá 
.
áá 
AddTransient
áá !
<
áá! "#
IStudentCourseManager
áá" 7
,
áá7 8"
StudentCourseManager
áá9 M
>
ááM N
(
ááN O
)
ááO P
;
ááP Q
services
ãã 
.
ãã 
AddTransient
ãã !
<
ãã! "

IValidator
ãã" ,
<
ãã, -
StudentRequest
ãã- ;
>
ãã; <
,
ãã< =
StudentValidator
ãã> N
>
ããN O
(
ããO P
)
ããP Q
;
ããQ R
services
åå 
.
åå 
AddTransient
åå !
<
åå! "

IValidator
åå" ,
<
åå, -
CourseRequest
åå- :
>
åå: ;
,
åå; <
CourseValidator
åå= L
>
ååL M
(
ååM N
)
ååN O
;
ååO P
services
çç 
.
çç 
AddTransient
çç !
<
çç! "

IValidator
çç" ,
<
çç, -
TeacherRequest
çç- ;
>
çç; <
,
çç< =
TeacherValidator
çç> N
>
ççN O
(
ççO P
)
ççP Q
;
ççQ R
services
éé 
.
éé 
AddTransient
éé !
<
éé! "

IValidator
éé" ,
<
éé, -"
StudentCourseRequest
éé- A
>
ééA B
,
ééB C$
StudentCourseValidator
ééD Z
>
ééZ [
(
éé[ \
)
éé\ ]
;
éé] ^
services
ëë 
.
ëë 
AddMvc
ëë 
(
ëë 
options
ëë #
=>
ëë$ &
{
íí 
options
ìì 
.
ìì 
Filters
ìì #
.
ìì# $
Add
ìì$ '
(
ìì' (
typeof
ìì( .
(
ìì. /$
ValidateModelAttribute
ìì/ E
)
ììE F
)
ììF G
;
ììG H
}
îî 
)
îî 
.
ïï %
SetCompatibilityVersion
ïï (
(
ïï( )"
CompatibilityVersion
ïï) =
.
ïï= >
Version_2_1
ïï> I
)
ïïI J
.
ññ 
AddJsonOptions
ññ 
(
ññ  
options
ññ  '
=>
ññ( *
{
óó 
options
òò 
.
òò   
SerializerSettings
òò  2
.
òò2 3#
ReferenceLoopHandling
òò3 H
=
òòI J#
ReferenceLoopHandling
òòK `
.
òò` a
Ignore
òòa g
;
òòg h
}
ôô 
)
ôô 
.
öö !
AddFluentValidation
öö $
(
öö$ %
)
öö% &
;
öö& '
}
õõ 	
public
ûû 
void
ûû 
	Configure
ûû 
(
ûû !
IApplicationBuilder
ûû 1
app
ûû2 5
,
ûû5 6!
IHostingEnvironment
ûû7 J
env
ûûK N
)
ûûN O
{
üü 	
if
†† 
(
†† 
env
†† 
.
†† 
IsDevelopment
†† !
(
††! "
)
††" #
)
††# $
{
°° 
app
¢¢ 
.
¢¢ '
UseDeveloperExceptionPage
¢¢ -
(
¢¢- .
)
¢¢. /
;
¢¢/ 0
}
££ 
else
§§ 
{
•• 
app
¶¶ 
.
¶¶ 
UseHsts
¶¶ 
(
¶¶ 
)
¶¶ 
;
¶¶ 
}
ßß 
var
©© 

locOptions
©© 
=
©© 
app
©©  
.
©©  !!
ApplicationServices
©©! 4
.
©©4 5

GetService
©©5 ?
<
©©? @
IOptions
©©@ H
<
©©H I(
RequestLocalizationOptions
©©I c
>
©©c d
>
©©d e
(
©©e f
)
©©f g
;
©©g h
app
™™ 
.
™™ $
UseRequestLocalization
™™ &
(
™™& '

locOptions
™™' 1
.
™™1 2
Value
™™2 7
)
™™7 8
;
™™8 9
app
¨¨ 
.
¨¨ !
UseForwardedHeaders
¨¨ #
(
¨¨# $
new
¨¨$ '%
ForwardedHeadersOptions
¨¨( ?
{
≠≠ 
ForwardedHeaders
ÆÆ  
=
ÆÆ! "
ForwardedHeaders
ÆÆ# 3
.
ÆÆ3 4
XForwardedFor
ÆÆ4 A
|
ÆÆB C
ForwardedHeaders
ÆÆD T
.
ÆÆT U
XForwardedProto
ÆÆU d
}
ØØ 
)
ØØ 
;
ØØ 
app
±± 
.
±± 
UseAuthentication
±± !
(
±±! "
)
±±" #
;
±±# $
app
≥≥ 
.
≥≥ 
UseCors
≥≥ 
(
≥≥ 
builder
≥≥ 
=>
≥≥  "
builder
≥≥# *
.
≥≥* +
AllowAnyOrigin
≥≥+ 9
(
≥≥9 :
)
≥≥: ;
.
≥≥; <
AllowAnyHeader
≥≥< J
(
≥≥J K
)
≥≥K L
.
≥≥L M
AllowAnyMethod
≥≥M [
(
≥≥[ \
)
≥≥\ ]
)
≥≥] ^
;
≥≥^ _
app
µµ 
.
µµ %
UseSwaggerDocumentation
µµ '
(
µµ' (
)
µµ( )
;
µµ) *
app
∑∑ 
.
∑∑ 
UseMiddleware
∑∑ 
<
∑∑ %
ErrorWrappingMiddleware
∑∑ 5
>
∑∑5 6
(
∑∑6 7
)
∑∑7 8
;
∑∑8 9
app
ππ 
.
ππ 
UseMvc
ππ 
(
ππ 
)
ππ 
;
ππ 
}
∫∫ 	
}
ªª 
}ºº ú
jC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Validators\CourseValidator.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '

Validators' 1
{ 
public 

class 
CourseValidator  
:! "
AbstractValidator# 4
<4 5
CourseRequest5 B
>B C
{		 
public

 
CourseValidator

 
(

 
)

  
{ 	
RuleFor 
( 
x 
=> 
x 
. 
CourseNo #
)# $
.$ %
NotEmpty% -
(- .
). /
./ 0
WithMessage0 ;
(; <
$"< >
{> ?
ValidatorConstants? Q
.Q R
CannotBeNullErrorR c
}c d
 : d g
{g h#
WebApiResourceConstantsh 
.	 Ä
CourseNo
Ä à
}
à â
"
â ä
)
ä ã
;
ã å
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
WithMessage, 7
(7 8
$"8 :
{: ;
ValidatorConstants; M
.M N
CannotBeNullErrorN _
}_ `
 : ` c
{c d#
WebApiResourceConstantsd {
.{ |
Name	| Ä
}
Ä Å
"
Å Ç
)
Ç É
.
É Ñ
MaximumLength
Ñ ë
(
ë í
$num
í î
)
î ï
.
ï ñ
WithMessage
ñ °
(
° ¢
$"
¢ §
{
§ • 
ValidatorConstants
• ∑
.
∑ ∏
MaxLengthError
∏ ∆
}
∆ «
 : 
«  
{
  À%
WebApiResourceConstants
À ‚
.
‚ „
Name
„ Á
}
Á Ë
, 25
Ë Ï
"
Ï Ì
)
Ì Ó
;
Ó Ô
RuleFor 
( 
x 
=> 
x 
. 
	TeacherId $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
.0 1
WithMessage1 <
(< =
$"= ?
{? @
ValidatorConstants@ R
.R S
CannotBeNullErrorS d
}d e
 : e h
{h i$
WebApiResourceConstants	i Ä
.
Ä Å
	TeacherId
Å ä
}
ä ã
"
ã å
)
å ç
;
ç é
} 	
} 
} ∏
qC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Validators\StudentCourseValidator.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '

Validators' 1
{ 
public 

class "
StudentCourseValidator '
:( )
AbstractValidator* ;
<; < 
StudentCourseRequest< P
>P Q
{		 
public

 "
StudentCourseValidator

 %
(

% &
)

& '
{ 	
RuleFor 
( 
x 
=> 
x 
. 
	StudentId $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
.0 1
WithMessage1 <
(< =
$"= ?
{? @
ValidatorConstants@ R
.R S
CannotBeNullErrorS d
}d e
 : e h
{h i$
WebApiResourceConstants	i Ä
.
Ä Å
	StudentId
Å ä
}
ä ã
"
ã å
)
å ç
;
ç é
RuleFor 
( 
x 
=> 
x 
. 
CourseId #
)# $
.$ %
NotEmpty% -
(- .
). /
./ 0
WithMessage0 ;
(; <
$"< >
{> ?
ValidatorConstants? Q
.Q R
CannotBeNullErrorR c
}c d
 : d g
{g h#
WebApiResourceConstantsh 
.	 Ä
CourseId
Ä à
}
à â
"
â ä
)
ä ã
;
ã å
} 	
} 
} ¸
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Validators\StudentValidator.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '

Validators' 1
{ 
public 

class 
StudentValidator !
:" #
AbstractValidator$ 5
<5 6
StudentRequest6 D
>D E
{		 
public

 
StudentValidator

 
(

  
)

  !
{ 	
RuleFor 
( 
x 
=> 
x 
. 
	StudentNo $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
.0 1
WithMessage1 <
(< =
$"= ?
{? @
ValidatorConstants@ R
.R S
CannotBeNullErrorS d
}d e
 : e h
{h i$
WebApiResourceConstants	i Ä
.
Ä Å
	StudentNo
Å ä
}
ä ã
"
ã å
)
å ç
;
ç é
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
WithMessage, 7
(7 8
$"8 :
{: ;
ValidatorConstants; M
.M N
CannotBeNullErrorN _
}_ `
 : ` c
{c d#
WebApiResourceConstantsd {
.{ |
Name	| Ä
}
Ä Å
"
Å Ç
)
Ç É
.
É Ñ
MaximumLength
Ñ ë
(
ë í
$num
í î
)
î ï
.
ï ñ
WithMessage
ñ °
(
° ¢
$"
¢ §
{
§ • 
ValidatorConstants
• ∑
.
∑ ∏
MaxLengthError
∏ ∆
}
∆ «
 : 
«  
{
  À%
WebApiResourceConstants
À ‚
.
‚ „
Name
„ Á
}
Á Ë
, 25
Ë Ï
"
Ï Ì
)
Ì Ó
;
Ó Ô
RuleFor 
( 
x 
=> 
x 
. 
Surname "
)" #
.# $
NotEmpty$ ,
(, -
)- .
.. /
WithMessage/ :
(: ;
$"; =
{= >
ValidatorConstants> P
.P Q
CannotBeNullErrorQ b
}b c
 : c f
{f g#
WebApiResourceConstantsg ~
.~ 
Surname	 Ü
}
Ü á
"
á à
)
à â
.
â ä
MaximumLength
ä ó
(
ó ò
$num
ò ö
)
ö õ
.
õ ú
WithMessage
ú ß
(
ß ®
$"
® ™
{
™ ´ 
ValidatorConstants
´ Ω
.
Ω æ
MaxLengthError
æ Ã
}
Ã Õ
 : 
Õ –
{
– —%
WebApiResourceConstants
— Ë
.
Ë È
Surname
È 
}
 Ò
, 25
Ò ı
"
ı ˆ
)
ˆ ˜
;
˜ ¯
} 	
} 
} ¸
kC:\Users\YEK\Documents\Projects\CustomFramework\CustomFramework.SampleWebApi\Validators\TeacherValidator.cs
	namespace 	
CustomFramework
 
. 
SampleWebApi &
.& '

Validators' 1
{ 
public 

class 
TeacherValidator !
:" #
AbstractValidator$ 5
<5 6
TeacherRequest6 D
>D E
{		 
public

 
TeacherValidator

 
(

  
)

  !
{ 	
RuleFor 
( 
x 
=> 
x 
. 
	TeacherNo $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
.0 1
WithMessage1 <
(< =
$"= ?
{? @
ValidatorConstants@ R
.R S
CannotBeNullErrorS d
}d e
 : e h
{h i$
WebApiResourceConstants	i Ä
.
Ä Å
	TeacherNo
Å ä
}
ä ã
"
ã å
)
å ç
;
ç é
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
WithMessage, 7
(7 8
$"8 :
{: ;
ValidatorConstants; M
.M N
CannotBeNullErrorN _
}_ `
 : ` c
{c d#
WebApiResourceConstantsd {
.{ |
Name	| Ä
}
Ä Å
"
Å Ç
)
Ç É
.
É Ñ
MaximumLength
Ñ ë
(
ë í
$num
í î
)
î ï
.
ï ñ
WithMessage
ñ °
(
° ¢
$"
¢ §
{
§ • 
ValidatorConstants
• ∑
.
∑ ∏
MaxLengthError
∏ ∆
}
∆ «
 : 
«  
{
  À%
WebApiResourceConstants
À ‚
.
‚ „
Name
„ Á
}
Á Ë
, 25
Ë Ï
"
Ï Ì
)
Ì Ó
;
Ó Ô
RuleFor 
( 
x 
=> 
x 
. 
Surname "
)" #
.# $
NotEmpty$ ,
(, -
)- .
.. /
WithMessage/ :
(: ;
$"; =
{= >
ValidatorConstants> P
.P Q
CannotBeNullErrorQ b
}b c
 : c f
{f g#
WebApiResourceConstantsg ~
.~ 
Surname	 Ü
}
Ü á
"
á à
)
à â
.
â ä
MaximumLength
ä ó
(
ó ò
$num
ò ö
)
ö õ
.
õ ú
WithMessage
ú ß
(
ß ®
$"
® ™
{
™ ´ 
ValidatorConstants
´ Ω
.
Ω æ
MaxLengthError
æ Ã
}
Ã Õ
 : 
Õ –
{
– —%
WebApiResourceConstants
— Ë
.
Ë È
Surname
È 
}
 Ò
, 25
Ò ı
"
ı ˆ
)
ˆ ˜
;
˜ ¯
} 	
} 
} 