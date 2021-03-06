| 场景     | 优化点                                                  | 效果                                      |
|----------|---------------------------------------------------------|-------------------------------------------|
| 整体优化 | UI去掉生成mipmap                                        | 减少包体大小，减少内存消耗                |
|          | 相同场景的UI打成图集                                    | 减少DrawCall，减少包体大小                |
|          | 尽量使用重复UI贴图，减少重复资源                        | 减少包体大小，减少内存消耗                |
|          | 不透明的UI贴图采用ETC1的压缩格式                        | 减少包体大小，减少内存消耗                |
|          | 透明的UI贴图采用ETC1+Alpha分离的方式                    | 减少包体大小，减少内存消耗                |
|          | 去掉Image的RaycastTarget                               | 减少Raycaster运算消耗                     |
|          | RawImage组件替换成Image                                 | 减少DrawCall                              |
|          | 关掉Label图，只有在标定时才启用                         | 减少CPU消耗                               |
|          | 关掉彩色图，只有在拍照时才启用                          | 减少CPU消耗                               |
|          | UI贴图尺寸修改                                          | 减少内存消耗，减少包体大小                |
|          | 减小RenderTexture尺寸                                   | 减少CPU消耗，减少内存消耗（效果非常明显） |
|          | 减小视频尺寸和码率                                      | 减少CPU消耗，减少包体大小                 |
|          | 大图尺寸修改为2的幂次方                                 | 减少内存消耗，减少包体大小                |
|          | 减少UI层级                                              | 减少CPU消耗                               |
|          | 合并不需要分开的图层                                    | 降低DrawCall，降低内存消耗，减少包体大小  |
|          | 减少UI透明区域，避免透明区域相互遮挡                    | 减少DrawCall                              |
|          | 整理UI结构，尽量使类似的UI在同一层                      | 减少DrawCall                              |
|          | 部分界面加上Canvas，分离动态UI                          | 减少网格重建消耗                          |
|          | 不需要接收事件的Canvas去掉GraphicRaycaster              | 减少Raycaster运算消耗                     |
|          | 去掉不必要的UI材质                                      | 减少DrawCall                              |
|          | 禁用掉不需要的Camera                                    | 减少渲染消耗                              |
|          | Camera只渲染需要的层                                    | 减少渲染消耗                              |
|          | Camera不使用skybox                                      | 较少渲染消耗                              |
|          | 减少不必要的字体阴影和描边                              | 减少GPU消耗                               |
|          | 较少Layout组件的使用                                    | 减少CPU消耗                               |
|          | 将经常需要开关的界面移除屏幕外而不用SetActive的方式隐藏 | 减少CPU消耗                               |
|          | 减少一些不必要的特效                                    | 较少CPU，GPU消耗                          |
|          | 减小特效面积，避免使用全屏特效                          | 较少渲染消耗                              |
|          | 使用对象池                                              | 减少创建和销毁对象消耗                    |
|          | 动态加载UI贴图使用Prefab而不是Texture                   | 减少DrawCall                              |
|          | 人偶网格合并，材质合并                                  | 减少DrawCall                              |
|          | 将一些不需要透明的贴图转为不透明                        | 减少包体大小，减少内存消耗                |
|          | 音频质量压缩                                          | 减少包体大小，减少内存消耗                |
|          | 音频设置为单通道                                       | 减少包体大小，减少内存消耗                |