import { Injectable } from '@nestjs/common';
import { CreateUserDTO } from './DTO/create-user.dto';
import { PrismaService } from '../primas/prisma.service';
import { UpdatePutUserDTO } from './DTO/update-put-user.dto';
import { UpdatePatchUserDTO } from './DTO/update-patch-user.dto';

@Injectable()
export class UserService {
  constructor(private readonly prisma: PrismaService) {}

  async createUser({ name, email, password }: CreateUserDTO) {
    return await this.prisma.user.create({
      data: { name, email, password }
    });
  }

  async getUserById(id: number) {
    return await this.prisma.user.findUnique({
      where: { id }
    });
  }

  async getAllUsers() {
    return await this.prisma.user.findMany();
  }

  async putUser(data: UpdatePutUserDTO, id: number) {
    return await this.prisma.user.update({
      where: { id },
      data: data
    });
  }

  async patchUser(data: UpdatePatchUserDTO, id: number) {
    return await this.prisma.user.update({
      where: { id },
      data: data
    });
  }
}