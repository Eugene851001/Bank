import { useAppSelector } from ".";

export const useNavigation = () => {

    const currentPage = useAppSelector((state) => state.navigation.currentPage);

    return { currentPage };
}