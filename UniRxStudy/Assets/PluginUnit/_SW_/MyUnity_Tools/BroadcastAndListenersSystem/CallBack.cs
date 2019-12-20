// ========================================================
// 描 述：封装系统所使用到的委托
// 作 者：SW
// 创建时间：2019/01/16 09:56:59
// 版 本：v 1.0
// ========================================================
public delegate void CallBack();
public delegate void CallBack<in T>(T arg);
public delegate void CallBack<in T, in TX>(T arg1, TX arg2);
public delegate void CallBack<in T, in TX, in TY>(T arg1, TX arg2, TY arg3);
public delegate void CallBack<in T, in TX, in TY, in TZ>(T arg1, TX arg2, TY arg3, TZ arg4);
public delegate void CallBack<in T, in TX, in TY, in TZ, in TW>(T arg1, TX arg2, TY arg3, TZ arg4, TW arg5);