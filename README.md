# Fix-HMD-Transform-cs
<img src="https://img.shields.io/badge/Unity-2019 or Later-blue?&logo=Unity"> <img src="https://img.shields.io/badge/License-MIT-green">

UnityでVR開発をする際に、HMDを任意の場所に固定するサンプルです。
Positionのみ固定し、Rotationは固定しません。
モーションキャプチャなどでアバターを操作する際に、VR空間のアバターの頭とHMDが一致するようにしたい場合などに使用します。


# Environment
- Unity 2019 or Later
    - サンプルとして2018以前で使用可能なものも用意してあります（ただし、2019以降では非推奨です）。


# Installation
- Unity上のVRの設定等を完了させておいてください。


# Usage
1. Unityを開き、AssetsフォルダにFixHMDPosition.csを読み込む
1. Hierarchyに配置したHMDのオブジェクトにFixHMDPosition.csをアタッチする（カメラに直接ではなく、Rigのオブジェクトにアタッチします）。
1. InspectorのFixed Transformに固定したい場所のGameObjectをアタッチします。
1. 実行すると、HMDの回転だけはそのまま反映され、位置は固定されます。
1. HMDからの映像を確認しながら、Offsetで値を調整してください。


# Description
- 固定したい場所の座標から、現在のHMDの実際の座標を引くことで移動を相殺し、固定されているように見せています。


## FixHMDPosition.cs
### Parameters
- fixedTransform: Transform
    - HMDを固定したい場所のGameObject。
    - VRアバターの場合、Left eyeとRight eyeの間に空のGameObjectを作り、それをアタッチすると良いと思います。
- offset: Vector3
    - HMDを固定する場所のオフセット
    - HMDからの映像に合わせて位置を微調整してください。
    - VRアバターの内側が見えてしまうような場合は、カメラのClipping PlanesのNearと合わせて調整すると良いかもしれません。

### Methods
- TryGetCenterEyePosition
    - HMDの目の中央位置を取得し、Vector3の変数positionに値を入れます。

- TryGetCenterEyeRotation
    - HMDの目の中央回転を取得し、Quaternionの変数rotationに値を入れます。
    - 今回は使用していません。


## FixHMDPosition_Legacy.cs
- 動作原理は同じですが、こちらはUnity 2019以降は非推奨の機能を使用しています。


# Note
- HMDを固定する方法はいくつかありますが、その1つだとお考えください。
- 例えば以下のような方法があります。
    - XRRigのTracked Pose DriverのTracking Typeを変更する
    - `XRDevice.DisableAutoXRCameraTracking`を使用する
    - Oculusの場合、OVR Managerの中のUse Position Trackingをオフにする
- これらがうまくいかない場合に、解決策の1つとしてお試しいただければと思います。

# Versions
- 1.0: 2020/11/22
- 1.1: 2022/4/18
    - 軽微な修正


# Author
- Takayoshi Hagiwara
    - Graduate School of Media Design, Keio University
    - Toyohashi University of Technology


# License
- MIT License