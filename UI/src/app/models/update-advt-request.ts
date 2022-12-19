import {IAdvt} from "./advt";

export class UpdateAdvtRequest{
  advt: IAdvt
  photos: string[]
  deletePhotoIds:number[]
}
