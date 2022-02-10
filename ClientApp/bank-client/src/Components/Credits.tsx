import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { DepositDemo } from "../Models/DepositDemo";
import { DeposistsService } from "../Services/DeposistsService";
import { CreditsService } from "../Services/CreditsService";
import { DateUtils } from "../utils/DateUtils";
import { ContractsList } from "./ContractsList";

export const Credits = () => {
   return <ContractsList getContracts={CreditsService.getAll} contractType="credits"/>
}