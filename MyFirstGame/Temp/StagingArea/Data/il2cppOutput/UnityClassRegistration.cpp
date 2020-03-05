extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_Director();
	RegisterModule_Director();

	void RegisterModule_Grid();
	RegisterModule_Grid();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_Tilemap();
	RegisterModule_Tilemap();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UnityConnect();
	RegisterModule_UnityConnect();

	void RegisterModule_Video();
	RegisterModule_Video();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

	void RegisterModule_UnityAnalytics();
	RegisterModule_UnityAnalytics();

	void RegisterModule_TextCore();
	RegisterModule_TextCore();

	void RegisterModule_TLS();
	RegisterModule_TLS();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_WebGL();
	RegisterModule_WebGL();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class Animation; template <> void RegisterUnityClass<Animation>(const char*);
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioSource; template <> void RegisterUnityClass<AudioSource>(const char*);
class AudioFilter; 
class AudioChorusFilter; 
class AudioDistortionFilter; 
class AudioEchoFilter; 
class AudioHighPassFilter; 
class AudioLowPassFilter; 
class AudioReverbFilter; 
class AudioReverbZone; 
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace Unity { class Cloth; } 
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class BoxCollider2D; template <> void RegisterUnityClass<BoxCollider2D>(const char*);
class CapsuleCollider2D; template <> void RegisterUnityClass<CapsuleCollider2D>(const char*);
class CircleCollider2D; template <> void RegisterUnityClass<CircleCollider2D>(const char*);
class CompositeCollider2D; template <> void RegisterUnityClass<CompositeCollider2D>(const char*);
class EdgeCollider2D; 
class PolygonCollider2D; template <> void RegisterUnityClass<PolygonCollider2D>(const char*);
class TilemapCollider2D; template <> void RegisterUnityClass<TilemapCollider2D>(const char*);
class ConstantForce; 
class Effector2D; 
class AreaEffector2D; 
class BuoyancyEffector2D; 
class PlatformEffector2D; 
class PointEffector2D; 
class SurfaceEffector2D; 
class FlareLayer; 
class GUIElement; template <> void RegisterUnityClass<GUIElement>(const char*);
namespace TextRenderingPrivate { class GUIText; } 
class GUITexture; 
class GUILayer; template <> void RegisterUnityClass<GUILayer>(const char*);
class GridLayout; template <> void RegisterUnityClass<GridLayout>(const char*);
class Grid; template <> void RegisterUnityClass<Grid>(const char*);
class Tilemap; template <> void RegisterUnityClass<Tilemap>(const char*);
class Halo; 
class HaloLayer; 
class IConstraint; 
class AimConstraint; 
class LookAtConstraint; 
class ParentConstraint; 
class PositionConstraint; 
class RotationConstraint; 
class ScaleConstraint; 
class Joint2D; 
class AnchoredJoint2D; 
class DistanceJoint2D; 
class FixedJoint2D; 
class FrictionJoint2D; 
class HingeJoint2D; 
class SliderJoint2D; 
class SpringJoint2D; 
class WheelJoint2D; 
class RelativeJoint2D; 
class TargetJoint2D; 
class LensFlare; 
class Light; 
class LightProbeGroup; 
class LightProbeProxyVolume; 
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class NavMeshAgent; 
class NavMeshObstacle; 
class OffMeshLink; 
class ParticleSystemForceField; 
class PhysicsUpdateBehaviour2D; 
class ConstantForce2D; 
class PlayableDirector; template <> void RegisterUnityClass<PlayableDirector>(const char*);
class Projector; 
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Skybox; 
class SortingGroup; 
class StreamingController; 
class Terrain; 
class VideoPlayer; template <> void RegisterUnityClass<VideoPlayer>(const char*);
class VisualEffect; 
class WindZone; 
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class BoxCollider; template <> void RegisterUnityClass<BoxCollider>(const char*);
class CapsuleCollider; template <> void RegisterUnityClass<CapsuleCollider>(const char*);
class CharacterController; 
class MeshCollider; 
class SphereCollider; template <> void RegisterUnityClass<SphereCollider>(const char*);
class TerrainCollider; 
class WheelCollider; 
namespace Unity { class Joint; } 
namespace Unity { class CharacterJoint; } 
namespace Unity { class ConfigurableJoint; } 
namespace Unity { class FixedJoint; } 
namespace Unity { class HingeJoint; } 
namespace Unity { class SpringJoint; } 
class LODGroup; 
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class OcclusionArea; 
class OcclusionPortal; 
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class BillboardRenderer; 
class LineRenderer; 
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class SkinnedMeshRenderer; 
class SpriteMask; 
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class SpriteShapeRenderer; 
class TilemapRenderer; template <> void RegisterUnityClass<TilemapRenderer>(const char*);
class TrailRenderer; 
class VFXRenderer; 
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRenderingPrivate { class TextMesh; } 
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class Tree; 
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class AssetBundle; 
class AssetBundleManifest; 
class AudioMixer; 
class AudioMixerController; 
class AudioMixerGroup; 
class AudioMixerGroupController; 
class AudioMixerSnapshot; 
class AudioMixerSnapshotController; 
class Avatar; 
class AvatarMask; template <> void RegisterUnityClass<AvatarMask>(const char*);
class BillboardAsset; 
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Flare; 
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
class LightProbes; 
class LocalizationAsset; 
class Material; template <> void RegisterUnityClass<Material>(const char*);
class ProceduralMaterial; 
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class Motion; template <> void RegisterUnityClass<Motion>(const char*);
class AnimationClip; template <> void RegisterUnityClass<AnimationClip>(const char*);
class NavMeshData; 
class OcclusionCullingData; 
class PhysicMaterial; 
class PhysicsMaterial2D; 
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderVariantCollection; 
class SpeedTreeWindAsset; 
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SubstanceArchive; 
class TerrainData; 
class TerrainLayer; 
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class CGProgram; template <> void RegisterUnityClass<CGProgram>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class BaseVideoTexture; 
class WebCamTexture; 
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class ProceduralTexture; 
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class CustomRenderTexture; 
class SparseTexture; 
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class VideoClip; 
class VisualEffectAsset; 
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class NavMeshProjectSettings; 
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class ScriptMapper; template <> void RegisterUnityClass<ScriptMapper>(const char*);
class StreamingManager; 
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class UnityConnectSettings; template <> void RegisterUnityClass<UnityConnectSettings>(const char*);
class VFXManager; 
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class NavMeshSettings; 
class OcclusionCullingSettings; 
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderPassAttachment; 

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 93 non stripped classes
	//0. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//1. Unity::Component
	RegisterUnityClass<Unity::Component>("Core");
	//2. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//3. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//4. Renderer
	RegisterUnityClass<Renderer>("Core");
	//5. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//6. Camera
	RegisterUnityClass<Camera>("Core");
	//7. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//8. Texture
	RegisterUnityClass<Texture>("Core");
	//9. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//10. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//11. GUIElement
	RegisterUnityClass<GUIElement>("Core");
	//12. GUILayer
	RegisterUnityClass<GUILayer>("Core");
	//13. GameObject
	RegisterUnityClass<GameObject>("Core");
	//14. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//15. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//16. GameManager
	RegisterUnityClass<GameManager>("Core");
	//17. Shader
	RegisterUnityClass<Shader>("Core");
	//18. Material
	RegisterUnityClass<Material>("Core");
	//19. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//20. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//21. Mesh
	RegisterUnityClass<Mesh>("Core");
	//22. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//23. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//24. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//25. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//26. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//27. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//28. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//29. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//30. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//31. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//32. UI::RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//33. Transform
	RegisterUnityClass<Transform>("Core");
	//34. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//35. Sprite
	RegisterUnityClass<Sprite>("Core");
	//36. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//37. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//38. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//39. BoxCollider2D
	RegisterUnityClass<BoxCollider2D>("Physics2D");
	//40. PolygonCollider2D
	RegisterUnityClass<PolygonCollider2D>("Physics2D");
	//41. CompositeCollider2D
	RegisterUnityClass<CompositeCollider2D>("Physics2D");
	//42. AnimationClip
	RegisterUnityClass<AnimationClip>("Animation");
	//43. Motion
	RegisterUnityClass<Motion>("Animation");
	//44. Animator
	RegisterUnityClass<Animator>("Animation");
	//45. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//46. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//47. Animation
	RegisterUnityClass<Animation>("Animation");
	//48. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//49. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//50. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//51. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//52. AudioSource
	RegisterUnityClass<AudioSource>("Audio");
	//53. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//54. Collider
	RegisterUnityClass<Collider>("Physics");
	//55. SphereCollider
	RegisterUnityClass<SphereCollider>("Physics");
	//56. GridLayout
	RegisterUnityClass<GridLayout>("Grid");
	//57. TextRendering::Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//58. Tilemap
	RegisterUnityClass<Tilemap>("Tilemap");
	//59. VideoPlayer
	RegisterUnityClass<VideoPlayer>("Video");
	//60. UI::Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//61. UI::CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//62. UI::CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");
	//63. PlayableDirector
	RegisterUnityClass<PlayableDirector>("Director");
	//64. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//65. CapsuleCollider
	RegisterUnityClass<CapsuleCollider>("Physics");
	//66. AvatarMask
	RegisterUnityClass<AvatarMask>("Animation");
	//67. TagManager
	RegisterUnityClass<TagManager>("Core");
	//68. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//69. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//70. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//71. InputManager
	RegisterUnityClass<InputManager>("Core");
	//72. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//73. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//74. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//75. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//76. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//77. ScriptMapper
	RegisterUnityClass<ScriptMapper>("Core");
	//78. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//79. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//80. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//81. UnityConnectSettings
	RegisterUnityClass<UnityConnectSettings>("UnityConnect");
	//82. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//83. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//84. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//85. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//86. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//87. TilemapRenderer
	RegisterUnityClass<TilemapRenderer>("Tilemap");
	//88. CircleCollider2D
	RegisterUnityClass<CircleCollider2D>("Physics2D");
	//89. CapsuleCollider2D
	RegisterUnityClass<CapsuleCollider2D>("Physics2D");
	//90. TilemapCollider2D
	RegisterUnityClass<TilemapCollider2D>("Tilemap");
	//91. CGProgram
	RegisterUnityClass<CGProgram>("Core");
	//92. Grid
	RegisterUnityClass<Grid>("Grid");

}
