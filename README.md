# はじめに
- このリポジトリは「ツナマヨ」（Xアカウント：@tunamayo1412）が制作したゲーム「りさじゅうシューティング」に関するものです
- ご利用いただくことでのトラブル等は一切責任を負いかねます

# ソースコード
- 本プロジェクトの主要なプログラム（C#スクリプト）は `Assets/Scripts` 内に格納されています

# コンセプト
- 電気通信大学の学園祭「調布祭」において、創作系サークル「TeRes」のサークル展示として制作しました
- 弾幕シューティングゲームを制作しようと思い、敵キャラとして大学のマスコットキャラクターである「りさじゅう」を採用しました
- 敵が撃ってくる弾はリサージュ曲線を描くようにしました

**`EnemyScript.cs`**
```csharp
// リサージュ曲線を描く弾幕
void bullethell(GameObject bullet, float width = 1, float height = 1, float xcycle = 1, float ycycle = 1, float xdensity = 1, float ydensity = 1)
{
    GameObject bul = Instantiate(bullet);
    bul.transform.position = new Vector3(width * Mathf.Cos(xcycle * Time.realtimeSinceStartup), height * Mathf.Sin(ycycle * Time.realtimeSinceStartup) + 5, 0);
    bul.transform.Rotate(0, 0, 360 * Mathf.Cos(Time.realtimeSinceStartup / xdensity) * Mathf.Sin(Time.realtimeSinceStartup / ydensity));
}
```

# ゲーム概要
- 三段階ある敵のHPを全て削り切ればクリアです

# デモ動画
<img src="https://raw.githubusercontent.com/wiki/tunamayo1412/lissajous-shooting/Lissajous.gif" width="500">

# 環境
- 開発言語：C#
- アプリケーション：Unity 2020.3.5f1
- 検証済みOS：Windows 10 Home 22H2

# 利用方法
- Unity 2020.3.5f1で本プロジェクトを起動してください
- また、TeResの調布祭用特設ページでもプレイすることが出来ます：<http://www.teres.club.uec.ac.jp/programming_team/game/2021/lissajous_shooting/index.html>

# 操作方法
- 移動：↑↓←→
- ショット：Z
- 低速移動：左Shift

# おわりに
- ゲーム制作のポートフォリオとしてリポジトリ公開させていただきました 
- 感想・コメント等あればご連絡下さると幸いです
