package md57c8540547322facad0cdada1c6ced536;


public class PolymorphicListItemTypesView_CustomAdapter
	extends md5dbd4653a432747a06c44c7bd2a4569e4.MvxAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemViewType:(I)I:GetGetItemViewType_IHandler\n" +
			"n_getViewTypeCount:()I:GetGetViewTypeCountHandler\n" +
			"";
		mono.android.Runtime.register ("Collections.Droid.Views.PolymorphicListItemTypesView+CustomAdapter, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PolymorphicListItemTypesView_CustomAdapter.class, __md_methods);
	}


	public PolymorphicListItemTypesView_CustomAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PolymorphicListItemTypesView_CustomAdapter.class)
			mono.android.TypeManager.Activate ("Collections.Droid.Views.PolymorphicListItemTypesView+CustomAdapter, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public PolymorphicListItemTypesView_CustomAdapter (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == PolymorphicListItemTypesView_CustomAdapter.class)
			mono.android.TypeManager.Activate ("Collections.Droid.Views.PolymorphicListItemTypesView+CustomAdapter, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public int getItemViewType (int p0)
	{
		return n_getItemViewType (p0);
	}

	private native int n_getItemViewType (int p0);


	public int getViewTypeCount ()
	{
		return n_getViewTypeCount ();
	}

	private native int n_getViewTypeCount ();

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
