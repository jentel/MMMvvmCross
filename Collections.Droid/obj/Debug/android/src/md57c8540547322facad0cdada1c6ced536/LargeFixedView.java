package md57c8540547322facad0cdada1c6ced536;


public class LargeFixedView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Collections.Droid.Views.LargeFixedView, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LargeFixedView.class, __md_methods);
	}


	public LargeFixedView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LargeFixedView.class)
			mono.android.TypeManager.Activate ("Collections.Droid.Views.LargeFixedView, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
