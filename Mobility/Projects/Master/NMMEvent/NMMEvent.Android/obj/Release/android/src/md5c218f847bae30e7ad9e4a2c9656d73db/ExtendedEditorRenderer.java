package md5c218f847bae30e7ad9e4a2c9656d73db;


public class ExtendedEditorRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.EditorRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("NMMEvent.Droid.ExtendedEditorRenderer, NMMEvent.Android", ExtendedEditorRenderer.class, __md_methods);
	}


	public ExtendedEditorRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ExtendedEditorRenderer.class)
			mono.android.TypeManager.Activate ("NMMEvent.Droid.ExtendedEditorRenderer, NMMEvent.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ExtendedEditorRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ExtendedEditorRenderer.class)
			mono.android.TypeManager.Activate ("NMMEvent.Droid.ExtendedEditorRenderer, NMMEvent.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ExtendedEditorRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ExtendedEditorRenderer.class)
			mono.android.TypeManager.Activate ("NMMEvent.Droid.ExtendedEditorRenderer, NMMEvent.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
