package md57c8540547322facad0cdada1c6ced536;


public class ExpandableView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Collections.Droid.Views.ExpandableView, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExpandableView.class, __md_methods);
	}


	public ExpandableView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExpandableView.class)
			mono.android.TypeManager.Activate ("Collections.Droid.Views.ExpandableView, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
