// public int Id { get; set; }
// public string Name { get; set; }
// public byte Currency { get; set; }
// public int Duration { get; set; }
// public bool Revocable { get; set; }
// public double Percent { get; set; }
// public bool Online { get; set; }
// public decimal? MinValue { get; set; }

export interface DepositPlanDTO {
    id:  number;
    name: string;
    currency: number;
    duration: number;
    revocable: boolean;
    percent: number;
    online: boolean;
    minValue: number;
}