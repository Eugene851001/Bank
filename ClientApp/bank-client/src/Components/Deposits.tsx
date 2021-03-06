import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { DepositDemo } from "../Models/DepositDemo";
import { DeposistsService } from "../Services/DeposistsService";
import { DateUtils } from "../utils/DateUtils";
import { ContractsList } from "./ContractsList";

export const Deposits = () => {
   return <ContractsList getContracts={DeposistsService.getAll} contractType="deposits"/>
}