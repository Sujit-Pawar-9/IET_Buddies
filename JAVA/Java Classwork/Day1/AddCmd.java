class AddCmd{
	public static void main(String[] args)
	{
		if(args.length>=2){
			int sum=0;
			for (int i=0;i<args.length;i++)
			{
				sum=sum+Integer.parseInt(args[i]);
			}
			System.out.println("RESULT "+ sum);
		}
		else
		{
		System.out.println("pls pass min 2 arg");
		}	
	}
}
