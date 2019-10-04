<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>06aeb963-e379-4fff-9951-de6bf6cb508f</Uid>
  <Name>UserMailbox</Name>
  <DisplayName>Пользователький почтовый ящик</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>398135e9-1c05-4571-a13f-2e7fe60a3a09</Uid>
      <Name>Uid</Name>
      <DisplayName>Уникальный идентификатор</DisplayName>
      <TypeUid>eb6e8ddc-fafe-4e0e-9018-1a7667012579</TypeUid>
      <Settings xsi:type="GuidSettings">
        <FieldName>Uid</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <IsSystem>true</IsSystem>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>824e8f7e-a414-4f0b-8c01-8579a556045a</Uid>
      <Name>CreationDate</Name>
      <DisplayName>Дата создания</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>CreationDate</FieldName>
        <SetCurrentDate>true</SetCurrentDate>
      </Settings>
      <Nullable>false</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>1</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>d0c00d8a-e003-427d-9942-f52cfb77b0f0</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>5200cb77-1e0f-4aa8-b89a-7df03624a320</Uid>
      <Name>CreationAuthor</Name>
      <DisplayName>Автор создания</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>CreationAuthor</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>2</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>b05ac6bd-eb8b-474a-a796-b53831a9967e</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>139faf94-ad8f-43c1-bc9a-f16c0aff553b</Uid>
      <Name>ChangeDate</Name>
      <DisplayName>Дата изменения</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>ChangeDate</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>3</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>12a6c5c4-12f8-4b2e-b7ea-5438974a2d25</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>8b6d961c-b64c-48b0-ade4-84ecda73c9a1</Uid>
      <Name>ChangeAuthor</Name>
      <DisplayName>Автор изменения</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>ChangeAuthor</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>4</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>d152e660-1ee9-4b5f-a614-df280e5b3f98</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>e11d2fdd-fb0e-4449-822b-cd42d10104ea</Uid>
      <Name>Owner</Name>
      <DisplayName>Владелец</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>Owner</FieldName>
        <CascadeMode>SaveUpdate</CascadeMode>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>5</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>3535c6a8-360e-45ba-95b7-0e0efeff8d5d</Uid>
      <Name>Server</Name>
      <DisplayName>Сервер</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>8786ded0-8825-482d-9446-e9a6eaf6caa0</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <FieldName>Server</FieldName>
        <CascadeMode>SaveUpdate</CascadeMode>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>6</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>ab12b139-f183-414f-8043-529a1c0936f7</Uid>
      <Name>EmailLogin</Name>
      <DisplayName>Почтовый логин</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>EmailLogin</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>7</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>a7295997-9533-4d16-9da5-d1cf9741eaea</Uid>
      <Name>EmailPassword</Name>
      <DisplayName>Почтовый пароль</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>EmailPassword</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <Visibility>Hidden</Visibility>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>ForceHidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>8</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>3c5b0672-8b44-403c-8f88-2e153a88fa82</Uid>
      <Name>LastMailUpdate</Name>
      <DisplayName>Время последнего сбора писем</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>LastMailUpdate</FieldName>
        <SetCurrentDate>true</SetCurrentDate>
      </Settings>
      <Nullable>false</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>9</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>18913b8c-1c8b-43bf-9754-a9421a93e5a2</Uid>
      <Name>EmailParticipant</Name>
      <DisplayName>Участник письма</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>71e11768-05e2-4788-b93e-7440e72b32b5</SubTypeUid>
      <Settings xsi:type="EntitySettings">
        <FieldName>EmailParticipant</FieldName>
        <CascadeMode>SaveUpdate</CascadeMode>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>10</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>5ac0cb4a-57c1-4a9d-b72d-017fec7aeb52</Uid>
      <Name>Aliases</Name>
      <DisplayName>Псевдонимы почтового ящика</DisplayName>
      <Description>алиасы через запятую: example@mail.ru, example2@mail.ru</Description>
      <TypeUid>317e3d72-9c47-4b68-926d-ba77a2579bc2</TypeUid>
      <Settings xsi:type="TextSettings">
        <FieldName>Aliases</FieldName>
        <MultiLine>true</MultiLine>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>11</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>d03fcad9-6a86-4fa2-a43d-9f170a5f39f6</Uid>
      <Name>Status</Name>
      <DisplayName>Статус</DisplayName>
      <TypeUid>849c1ac9-4d46-4194-8cbb-43f84adf9c17</TypeUid>
      <SubTypeUid>c2eb5adb-5d14-47ad-a304-58adb8d5432f</SubTypeUid>
      <Settings xsi:type="EnumSettings">
        <FieldName>Status</FieldName>
        <DefaultValue>d680397a-e681-41c5-91c7-115d7bb1dc36</DefaultValue>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>12</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>62b54065-2e37-464e-8673-d1b24d8bb901</Uid>
      <Name>Error</Name>
      <DisplayName>Описание ошибки</DisplayName>
      <TypeUid>317e3d72-9c47-4b68-926d-ba77a2579bc2</TypeUid>
      <Settings xsi:type="TextSettings">
        <FieldName>Error</FieldName>
        <MultiLine>true</MultiLine>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>13</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>e106dc79-9b3e-46c7-b15a-c108ee9f40bd</Uid>
      <Name>PasswordEncoded</Name>
      <DisplayName>Пароль зашифрованый</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>PasswordEncoded</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Display</ViewType>
            <Visibility>Hidden</Visibility>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
            <Visibility>Hidden</Visibility>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>14</Order>
    </PropertyMetadata>
  </Properties>
  <FormsScheme>FormConstructor</FormsScheme>
  <DefaultForms>
    <CreateUid>f686dac5-1da5-43c6-abe7-e7f9034b594c</CreateUid>
    <EditUid>4cbcd7d3-62e1-4791-a2a1-a0760fab4e0c</EditUid>
    <DisplayUid>df401dc3-706d-4cb1-9402-28f4a376e043</DisplayUid>
  </DefaultForms>
  <Forms>
    <FormViewItem>
      <Name>Form</Name>
      <Uid>df401dc3-706d-4cb1-9402-28f4a376e043</Uid>
      <Items>
        <RootViewItem xsi:type="ColumnsLayoutViewItem">
          <Name>ColumnsLayout1</Name>
          <Uid>a3bee797-842f-422f-be4b-e9b9c74bc585</Uid>
          <Items>
            <RootViewItem xsi:type="ColumnViewItem">
              <Name>Column1</Name>
              <Uid>6b9506fa-d5a9-4341-9547-563d19b447e8</Uid>
              <Items>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property2</Name>
                  <Uid>bfc6e961-273c-404f-a09e-dea2d0864ad7</Uid>
                  <Property>3535c6a8-360e-45ba-95b7-0e0efeff8d5d</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property3</Name>
                  <Uid>17978f5f-325f-4490-a682-408fa727ea79</Uid>
                  <Property>ab12b139-f183-414f-8043-529a1c0936f7</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property5</Name>
                  <Uid>2a2027e4-9f93-42ba-8ab8-f368639431c0</Uid>
                  <Property>5ac0cb4a-57c1-4a9d-b72d-017fec7aeb52</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property4</Name>
                  <Uid>edfc1731-3c47-428b-be10-b7e1639d0272</Uid>
                  <Property>e11d2fdd-fb0e-4449-822b-cd42d10104ea</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property1</Name>
                  <Uid>34a26ae0-1ca8-4f1c-8df9-0fdeb89fbcd9</Uid>
                  <Property>18913b8c-1c8b-43bf-9754-a9421a93e5a2</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property6</Name>
                  <Uid>b399aecc-ef63-486e-b998-63ca7d5c5e48</Uid>
                  <Property>d03fcad9-6a86-4fa2-a43d-9f170a5f39f6</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property7</Name>
                  <Uid>ded1e15e-fc54-4385-bde2-747bfca3a0fd</Uid>
                  <HideEmpty>true</HideEmpty>
                  <Property>62b54065-2e37-464e-8673-d1b24d8bb901</Property>
                  <Attributes />
                </RootViewItem>
              </Items>
            </RootViewItem>
          </Items>
        </RootViewItem>
      </Items>
      <DisplayName>Просмотр</DisplayName>
      <ReadOnly>true</ReadOnly>
    </FormViewItem>
    <FormViewItem>
      <Name>Form</Name>
      <Uid>f686dac5-1da5-43c6-abe7-e7f9034b594c</Uid>
      <Items>
        <RootViewItem xsi:type="ColumnsLayoutViewItem">
          <Name>ColumnsLayout1</Name>
          <Uid>348fc15f-7673-4ea6-a4c5-bbc3c501fe39</Uid>
          <Items>
            <RootViewItem xsi:type="ColumnViewItem">
              <Name>Column1</Name>
              <Uid>55af7340-3fa7-48fe-8ef9-a65d26075a3b</Uid>
              <Items>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property2</Name>
                  <Uid>0fa4c3da-4c05-4677-b8bd-0828308cde84</Uid>
                  <Property>3535c6a8-360e-45ba-95b7-0e0efeff8d5d</Property>
                  <Attributes>
                    <Required>true</Required>
                  </Attributes>
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property5</Name>
                  <Uid>67d67528-5ac5-403a-ac6e-24e6fca9a296</Uid>
                  <Property>ab12b139-f183-414f-8043-529a1c0936f7</Property>
                  <Attributes>
                    <Required>true</Required>
                  </Attributes>
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property6</Name>
                  <Uid>92ef4126-bbe3-49e4-baa2-eff979e30d00</Uid>
                  <Property>a7295997-9533-4d16-9da5-d1cf9741eaea</Property>
                  <Attributes>
                    <Required>true</Required>
                  </Attributes>
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property3</Name>
                  <Uid>6e53f154-36d8-4a9c-80c1-37f4639e5ed0</Uid>
                  <Property>5ac0cb4a-57c1-4a9d-b72d-017fec7aeb52</Property>
                  <Attributes />
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property4</Name>
                  <Uid>6bc2bd08-fb30-4475-88dd-4d64aa578de2</Uid>
                  <Property>3c5b0672-8b44-403c-8f88-2e153a88fa82</Property>
                  <Attributes>
                    <Description>Новые письма будут загржены начиная с этой даты</Description>
                    <Required>true</Required>
                  </Attributes>
                </RootViewItem>
                <RootViewItem xsi:type="PropertyViewItem">
                  <Name>Property1</Name>
                  <Uid>b1b101ef-cf7f-4d75-a0e4-6abf17aa18b0</Uid>
                  <Property>e11d2fdd-fb0e-4449-822b-cd42d10104ea</Property>
                  <Attributes>
                    <Required>true</Required>
                  </Attributes>
                </RootViewItem>
              </Items>
            </RootViewItem>
          </Items>
        </RootViewItem>
      </Items>
      <DisplayName>Создание/Редактирование</DisplayName>
    </FormViewItem>
  </Forms>
  <FormTransformations>
    <FormViewItemTransformation>
      <Uid>f686dac5-1da5-43c6-abe7-e7f9034b594c</Uid>
      <FormName>Form</FormName>
      <NewFormUid>4cbcd7d3-62e1-4791-a2a1-a0760fab4e0c</NewFormUid>
      <NewFormName>Form</NewFormName>
      <NewFormDisplayName>Редактирование</NewFormDisplayName>
      <Items>
        <ViewItemTransformation xsi:type="ViewItemTransformationChange" Type="EleWise.ELMA.Model.Views.PropertyViewItem, EleWise.ELMA.SDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cb29d04eca9b031d">
          <Uid>b1b101ef-cf7f-4d75-a0e4-6abf17aa18b0</Uid>
          <PropertyName>Attributes.ReadOnly</PropertyName>
          <Value xsi:type="xsd:boolean">true</Value>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationChange" Type="EleWise.ELMA.Model.Views.PropertyViewItem, EleWise.ELMA.SDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cb29d04eca9b031d">
          <Uid>b1b101ef-cf7f-4d75-a0e4-6abf17aa18b0</Uid>
          <PropertyName>Attributes.Required</PropertyName>
          <Value xsi:type="xsd:boolean">false</Value>
        </ViewItemTransformation>
      </Items>
    </FormViewItemTransformation>
  </FormTransformations>
  <TableViews>
    <TableView>
      <Uid>2b183cbc-bbcc-4b07-8eb6-16de28e59de3</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <TitlePropertyUid>ab12b139-f183-414f-8043-529a1c0936f7</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>ca2f3a69-b8d4-427f-9c32-d99985594dac</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>UserMailbox</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <Filterable>true</Filterable>
  <Filter />
  <Actions />
</Entity>