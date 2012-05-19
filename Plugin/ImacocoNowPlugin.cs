using System;
using System.Collections.Generic;
using System.Text;
using EbiSoft.Library.PluginFramework;

namespace PCGPS.Plugin
{
    /// <summary>
    /// 今ココなう！を拡張するプラグインの基本クラスです
    /// このほかに、PluginBase.OnLoad()、PluginBase.OnUnload()を実装する必要があります。
    /// 参照設定に
    /// ImacocoNow\plugin\EbiSoft.Library.PluginFramework.dll
    /// ImacocoNow.exe(もしくはImacocoNowプロジェクト)
    /// を追加してください。
    /// </summary>
    public abstract class ImacocoNowPlugin : PluginBase
    {
        /// <summary>
        /// プラグインの名称を取得する
        /// </summary>
        /// <returns></returns>
        public abstract string PluginName();

        /// <summary>
        /// 設定ダイアログがあるかどうかを返す
        /// </summary>
        /// <returns></returns>
        public abstract bool HasConfigDialog();

        /// <summary>
        /// 設定ダイアログを開く
        /// </summary>
        public abstract void OpenConfigDialog();

        /// <summary>
        /// 位置情報が更新されたときに呼び出される。
        /// メインスレッドとは別のスレッドで呼び出されるので、UIを扱うときは注意
        /// </summary>
        /// <param name="location"></param>
        public abstract void OnLocationChanged(GPSTrackPoint location);

        /// <summary>
        /// 住所を取得したときに呼び出される
        /// メインスレッドとは別のスレッドで呼び出されるので、UIを扱うときは注意
        /// </summary>
        /// <param name="address"></param>
        public abstract void OnGetAddress(string address);

        /// <summary>
        /// 近接ユーザー情報を取得したときに呼び出される
        /// メインスレッドとは別のスレッドで呼び出されるので、UIを扱うときは注意
        /// 辞書は
        /// [ユーザーID, [キー, 値]]
        /// の構造になっている
        /// キーはImacocoNow/Form1.csに定義してある
        /// </summary>
        /// <param name="userInfo"></param>
        public abstract void OnGetUserLocation(Dictionary<string, Dictionary<string, string>> userInfo);
    }
}
