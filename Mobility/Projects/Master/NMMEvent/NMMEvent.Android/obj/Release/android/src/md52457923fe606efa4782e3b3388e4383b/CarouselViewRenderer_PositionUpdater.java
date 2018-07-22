package md52457923fe606efa4782e3b3388e4383b;


public class CarouselViewRenderer_PositionUpdater
	extends android.support.v7.widget.RecyclerView.AdapterDataObserver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemRangeInserted:(II)V:GetOnItemRangeInserted_IIHandler\n" +
			"n_onItemRangeRemoved:(II)V:GetOnItemRangeRemoved_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.CarouselViewRenderer+PositionUpdater, Xamarin.Forms.CarouselView.Android", CarouselViewRenderer_PositionUpdater.class, __md_methods);
	}


	public CarouselViewRenderer_PositionUpdater ()
	{
		super ();
		if (getClass () == CarouselViewRenderer_PositionUpdater.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.CarouselViewRenderer+PositionUpdater, Xamarin.Forms.CarouselView.Android", "", this, new java.lang.Object[] {  });
	}

	public CarouselViewRenderer_PositionUpdater (md52457923fe606efa4782e3b3388e4383b.CarouselViewRenderer p0)
	{
		super ();
		if (getClass () == CarouselViewRenderer_PositionUpdater.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.CarouselViewRenderer+PositionUpdater, Xamarin.Forms.CarouselView.Android", "Xamarin.Forms.Platform.CarouselViewRenderer, Xamarin.Forms.CarouselView.Android", this, new java.lang.Object[] { p0 });
	}


	public void onItemRangeInserted (int p0, int p1)
	{
		n_onItemRangeInserted (p0, p1);
	}

	private native void n_onItemRangeInserted (int p0, int p1);


	public void onItemRangeRemoved (int p0, int p1)
	{
		n_onItemRangeRemoved (p0, p1);
	}

	private native void n_onItemRangeRemoved (int p0, int p1);

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
