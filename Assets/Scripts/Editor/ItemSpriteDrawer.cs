using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemSprite),true)]
public class ItemSpriteDrawer : PropertyDrawer{
    string idSearch;
    bool validKey = true;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        idSearch =  property.FindPropertyRelative("id").stringValue;
        
        position.y += EditorGUIUtility.singleLineHeight;

        var warningRect = new Rect(position.x, position.y, 30, 30);
        var idRect = new Rect(position.x + 15, position.y, position.width - 15,EditorGUIUtility.singleLineHeight);
        var spriteRect = new Rect(position.x + (position.width/2) - 50, position.y + EditorGUIUtility.singleLineHeight, 100, 100);
        var warning = EditorGUIUtility.IconContent("console.warnicon.sml");
        warning.tooltip = "Couldn't find a Sprite with this key. A default Sprite will be used instead.";

        EditorGUI.indentLevel++;

        string oldString = idSearch;
        EditorGUI.BeginChangeCheck();
        idSearch = EditorGUI.DelayedTextField(idRect, "ID", idSearch);
        if(EditorGUI.EndChangeCheck()){
            //DelayedTextField conta tirar o foco da caixa como uma mudança, portanto, é feita
            //uma verificação do conteúdo antes e depois da alteração acusada
            //afim de impedir falsos positivos
            if(idSearch != oldString){
                Sprite sp;
                property.FindPropertyRelative("id").stringValue = idSearch;
                validKey = DatabaseManager.spriteData.data.TryGetValue(idSearch, out sp);
                property.FindPropertyRelative("icon").objectReferenceValue = sp;
            }
        }
        Sprite tex = (Sprite) property.FindPropertyRelative("icon").objectReferenceValue;
        GUIStyle style = new GUIStyle();
        style.stretchHeight = true;
        style.stretchWidth = true;
        
        if(tex != null){
            style.normal.background = tex.texture;
            GUI.Button(spriteRect,"", style);
        }
            
        if(!validKey)
            GUI.Button(warningRect,warning,GUIStyle.none);
        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
        float height = 2 * EditorGUIUtility.singleLineHeight;
        if(property.FindPropertyRelative("icon").objectReferenceValue == null){
            return height;
        }else{
            return height + 100;
        }
    }
}