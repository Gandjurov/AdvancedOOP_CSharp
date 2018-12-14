namespace FestivalManager.Entities.Instruments
{
    public class Bass : Instrument
    {
	    public int RepairAmountConst = 80;
	    protected override int RepairAmount => RepairAmountConst;
    }
}
