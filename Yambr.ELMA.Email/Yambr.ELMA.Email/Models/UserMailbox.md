<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>06aeb963-e379-4fff-9951-de6bf6cb508f</Uid>
  <Name>UserMailbox</Name>
  <DisplayName>UserMailbox</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>00000000-0000-0000-0000-000000000000</BaseClassUid>
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
      <Uid>8aba5c2c-e2e6-466a-8fbe-9fbf6287db1e</Uid>
      <Name>Name</Name>
      <DisplayName>Наименование</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>Name</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <Required>true</Required>
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
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>1</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
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
      <Order>2</Order>
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
      <Order>3</Order>
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
      <Order>4</Order>
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
      <Order>5</Order>
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
      <Order>6</Order>
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
      <Order>7</Order>
    </PropertyMetadata>
  </Properties>
  <PropertiesDiffContainer />
  <DefaultForms>
    <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
    <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
    <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
    <ActionGuids />
    <FormSettings />
  </DefaultForms>
  <Forms />
  <FormTransformations />
  <FormViews />
  <TableViews>
    <TableView>
      <Uid>2b183cbc-bbcc-4b07-8eb6-16de28e59de3</Uid>
      <ViewType>List</ViewType>
      <SortDescriptors />
      <GroupDescriptors />
    </TableView>
  </TableViews>
  <TitlePropertyUid>8aba5c2c-e2e6-466a-8fbe-9fbf6287db1e</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>ca2f3a69-b8d4-427f-9c32-d99985594dac</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>UserMailbox</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <ParentPropertyUid>00000000-0000-0000-0000-000000000000</ParentPropertyUid>
  <IsGroupPropertyUid>00000000-0000-0000-0000-000000000000</IsGroupPropertyUid>
  <Filter>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseClassUid>00000000-0000-0000-0000-000000000000</BaseClassUid>
    <Properties />
    <PropertiesDiffContainer />
    <DefaultForms>
      <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
      <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
      <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
      <ActionGuids />
      <FormSettings />
    </DefaultForms>
    <Forms />
    <FormTransformations />
    <FormViews />
    <TableViews />
    <TitlePropertyUid>00000000-0000-0000-0000-000000000000</TitlePropertyUid>
  </Filter>
  <ImplementedExtensionUids />
  <Actions>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseTypeUid>00000000-0000-0000-0000-000000000000</BaseTypeUid>
    <Values />
  </Actions>
  <TableParts />
</Entity>