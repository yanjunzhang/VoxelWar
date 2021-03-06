# VoxelBattle
-------------------------
DEMO
===
**进入MainLoad场景可以体验游戏，也可下载Windows的包进行试玩。由于是学习性质的，很多地方存在瑕疵，请不要介意**

**unity版本为5.6.0**
视频 链接：https://v.youku.com/v_show/id_XMjg4MDYzMDI4NA==.html

2017/7/8更新：

- 修改了地图，为低模卡通风格城镇，并增加了遮挡剔除。
- 修改了敌人，为像素风格僵尸，有两个动作：站立和移动，敌人属性随机，包括血量、伤害、巡逻范围、移动速度、杀死获得的经验值都呈线性增长，系数为0-1。
- 新增加了若干音效：载入时的音乐，更换武器时的音效，背景音乐，并在游戏菜单里增加了音量调节功能。
- 更改了拾取武器的实现逻辑，原模式为在`OnCollisionStay`下获取玩家按键来实现切换，但是打包出来的游戏好像识别不到，故采用状态机制，当玩家`OnCollisionEnter`后，可以进行切换。
- 优化了若干代码在编辑器模式下正常，打包后速度过快的问题，原因系生命周期函数。



---
### 游戏介绍 ###
> 该DEMO主要为个人学习过程中的一些技术点的复习，所以素材方面显得很单薄，作为一个程序员我觉得素材不是最重要的，如何熟练地去使用素材才是最主要的。
>  
>  游戏操作通过鼠标的移动使玩家方向转动，**WASD**为前后左右移动，**QE**键为镜头旋转（这部分操作，体验下来不是很顺畅，有待改进），
>  **TAB**键为更换武器，目前更换武器只能是顺序切换至下一个，如果需要切换到上一种类型的武器，就需要连续切换两次。
>**F**键在靠近浮动的武器时可以进行切换，地图上的武器会随机进行变化，不同的武器有不同的效果。

### UI界面 ###
>游戏比较满意的部分其实是UI部分，因为现成的没有符合风格的素材，而正好magicalVoxel可以输出iso格式的图片，用来做icon正合适不过。所以就干脆自己设计整个界面的UI。
>
>玩家的武器系统有近战、枪械、和法杖三种，不同的武器会在界面进行更换，并且更换图片的时候会有动画效果，看起来还是非常不错的，遗憾的是DEMO中音效方面做得较差，除了不同的法杖发出的法球及不同的枪射出的子弹，它们的音效还是做了区分的。
>
### 武器系统 ###
>因为游戏的特色就是武器的种类不同拥有不同的武器特性及特效，所以通过`XML`表来进行读取武器的相关信息，XML表格格式如下：



    <ToxicStaff type="0">
      <冷却>3</冷却>
      <买价>800</买价>
      <卖价>400</卖价>
      <攻击距离>3</攻击距离>
      <伤害>9</伤害>
      <冲击>2.2</冲击>
      <健康值消耗>5</健康值消耗>
      <子弹特效名></子弹特效名>
      <魔法特效名>ElementalBall4</魔法特效名>
      <击中特效名></击中特效名>
      <后坐力>0</后坐力>
      <发射物飞行速度>15</发射物飞行速度>
      <爆炸半径>5</爆炸半径>
      <爆炸伤害>20</爆炸伤害>
      <准备时长>0.5</准备时长>
      <是否可以穿墙>0</是否可以穿墙>
    </ToxicStaff>

>type为武器类型，这些属性基本涵盖了游戏里希望出现的效果，目前DEMO中实现的有攻击距离、伤害、冲击（击退值）、健康值消耗、特效、后坐力、速度。
>其中是否可以穿墙这一块，原来计划是通过碰撞体和触发器之间进行区分，目前还没深入，不知道会不会有坑。
>爆炸这一块，感觉难度不大，目前还没添加。
### 插件的使用 ###
- ngui
	>关于UI这块，其实应该用UGUI更好一点，但因为之前看视频学习的时候用的是ngui，而且手头正好有ngui的插件资源，想着试试的心态就选用了ngui，以后可以尝试下ugui。
- easysave2
	>这个插件其实在DEMO中并没有怎么体现，因为根据游戏的设置，需要在战斗结束后进行保存，所以在demo场景里没来得及进行玩家信息的存储。
	
### 收获 ###
>这么一个DEMO下来，可以说在各个技术点都有着不同程度的收获，其中比较在意的一个点就是，游戏全部调试完后，打包的时候发现射不出子弹了，在游戏里都是一切正常的，对于没有经验的我来说是直接抓瞎了，后来想到，可能是文件路径的问题，打包的时候没有打包进游戏，导致了XML表读取不到，对于资源这一块，**Resources和StreamingAssets**的文件夹存放还是需要进一步的研究和实践。
>
### 设想 ###
>其实这种风格的游戏适合做成联机对战性质的，通过丰富多样的武器及技能搭配，可以有很多内容的拓展。限于技术原因，对网络这一块暂时还没有精力去深入研究，之前研究了`Photon`这个插件，通过它即可完成联机部分，但是测试下来延迟较高，因为它是直接与官网进行传输的，总体效果感觉不佳，也有可能是方向不对，反正目前来说网络这一块还是放在后面进行学习。
>
>游戏目前是没有做优化的，未来如有时间的话可以做一下简单的优化，把代码进行下重构，并且加入热更新，这一块感觉还是比较重要的，另外lua脚本在热更新中的使用也是我接下来需要学习的内容。
