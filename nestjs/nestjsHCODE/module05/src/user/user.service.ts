import { Injectable, NotFoundException } from '@nestjs/common';
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
    return await this.prisma.user.findUnique({//Retorna pelo id pq é único
      where: { id }
    });
  }

  async getAllUsers() {
    return await this.prisma.user.findMany();//Retorna tudo
  }

  async putUser({ email, name, password, birthAt }: UpdatePutUserDTO, id: number) {
    await this.hasUser(id);

    if (!birthAt) {
      birthAt = null;
    } else {
      birthAt = String(new Date(birthAt));
    }

    return await this.prisma.user.update({
      where: { id },
      data: { email, name, password, birthAt }
    });
  }

  async patchUser(data: UpdatePatchUserDTO, id: number) {
    await this.hasUser(id);

    if (data.birthAt) {
      data.birthAt = String(new Date(data.birthAt));
    }

    return await this.prisma.user.update({
      where: { id },
      data: data
    });
  }

  async deleteUser(id: number) {
    await this.hasUser(id);

    return await this.prisma.user.delete({
      where: { id }
    });
  }

  async hasUser(id: number) {
    const hasUser = await this.getUserById(id);
  
    if (!hasUser) {
      throw new NotFoundException(`Usuário com o ${id} não encontrado!`);
    }
  }
}